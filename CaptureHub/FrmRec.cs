using System.Diagnostics;

namespace Rec
{
    public partial class FrmRec : Form
    {
        private readonly RecorderService _recorderService;
        private CancellationTokenSource? _cancelationTokenSource;


        //Atualização dinamicas das janelas e monitores
        private readonly List<WindowInfo> _lastWindows = [];
        private readonly List<MonitorInfo> _lastMonitors = [];
        private readonly BindingSource _windowsSource = new();
        private readonly BindingSource _monitorsSource = new();
        private string? _videoFilePath;
        private readonly string _videosFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

        public FrmRec()
        {
            InitializeComponent();
            _recorderService = new RecorderService();
        }

        #region Form Events

        protected void FrmRec_Load(object sender, EventArgs e)
        {
            this.Text = $"{this.Text} - v{Application.ProductVersion}";
            this.AutoScaleMode = AutoScaleMode.Dpi;

            cbbWindows.DataSource = _windowsSource;
            cbbWindows.DisplayMember = nameof(WindowInfo.Title);

            cbbMonitors.DataSource = _monitorsSource;
            cbbMonitors.DisplayMember = nameof(MonitorInfo.Name);

            _cancelationTokenSource = new CancellationTokenSource();
            _ = RefreshSourcesLoopAsync(_cancelationTokenSource.Token);
        }

        private async void FrmRec_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_recorderService.IsRecording)
            {
                await _recorderService.StopAsync();
            }

            _cancelationTokenSource?.Cancel();
            _cancelationTokenSource?.Dispose();
            _recorderService.Dispose();
        }

        #endregion

        #region  Rec/Stop

        private void btnPathFile_Click(object sender, EventArgs e)
        {
            sfdVideo.InitialDirectory = _videosFolder;

            if (sfdVideo.ShowDialog() == DialogResult.OK)
            {
                _videoFilePath = sfdVideo.FileName;
                txtVideoFile.Text = _videoFilePath;
            }
        }

        private async void btnRec_Click(object sender, EventArgs e)
        {
            try
            {
                WindowInfo? window = null;

                if (string.IsNullOrWhiteSpace(_videoFilePath))
                {
                    string fileName = $"Capture-Hub_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.mp4";
                    _videoFilePath = Path.Combine(_videosFolder, fileName);

                    if (MessageBox.Show($"Você não informou um nome do arquivo do vídeo que será gerado. Deseja que o sistema crie um automaticamente neste endereço {_videoFilePath} ?", "Video File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    else
                        txtVideoFile.Text= _videoFilePath;
                }

                if (File.Exists(_videoFilePath))
                {
                    MessageBox.Show("Existe um arquivo com o mesmo nome na pasta de destino. Informe um nome diferente.", "Video File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbbWindows.SelectedIndex > -1 && cbbWindows.SelectedItem!.ToString() != "Tela Inteira")
                    window = (WindowInfo)cbbWindows.SelectedItem;

                var monitor = (MonitorInfo)cbbMonitors.SelectedItem!;
                if (monitor == null) return;

                string monitorDeviceName = monitor.DeviceName;

                await _recorderService.StartAsync(
                                                _videoFilePath,
                                                window?.Handle,
                                                monitorDeviceName);

                btnStop.Enabled = true;
                btnRec.Enabled = false;
                cbbMonitors.Enabled = false;
                cbbWindows.Enabled = false;
                tslStatus.Text = "Gravando...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                await _recorderService.StopAsync();

                btnStop.Enabled = false;
                btnRec.Enabled = true;
                cbbMonitors.Enabled = true;
                cbbWindows.Enabled = true;
                tslStatus.Text = "Gravação Interrompida";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Monitor/Monitors

        private void RefreshMonitorsCombo(List<MonitorInfo> monitors)
        {
            var selectedDevice =
                (cbbMonitors.SelectedItem as MonitorInfo)?.DeviceName;

            cbbMonitors.BeginUpdate();

            try
            {
                cbbMonitors.DataSource = null;
                cbbMonitors.DataSource = monitors;
                cbbMonitors.DisplayMember = nameof(MonitorInfo.Name);

                if (!string.IsNullOrWhiteSpace(selectedDevice))
                {
                    var selected = monitors.FirstOrDefault(
                        m => m.DeviceName == selectedDevice);

                    if (selected != null)
                        cbbMonitors.SelectedItem = selected;
                }
            }
            finally
            {
                cbbMonitors.EndUpdate();
            }
        }

        private void RefreshWindowsCombo(List<WindowInfo> windows)
        {
            var selectedHandle =
                (cbbWindows.SelectedItem as WindowInfo)?.Handle;

            cbbWindows.BeginUpdate();

            try
            {
                cbbWindows.DataSource = null;
                cbbWindows.DataSource = windows;
                cbbWindows.DisplayMember = nameof(WindowInfo.Title);

                if (selectedHandle != null)
                {
                    var selected = windows.FirstOrDefault(
                        w => w.Handle == selectedHandle);

                    if (selected != null)
                        cbbWindows.SelectedItem = selected;
                }
            }
            finally
            {
                cbbWindows.EndUpdate();
            }
        }

        private async Task RefreshSourcesLoopAsync(CancellationToken token)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            while (await timer.WaitForNextTickAsync(token))
            {
                try
                {
                    var windowsTask = Task.Run(
                        () => WindowEnumerator.GetOpenWindows(),
                        token);

                    var monitorsTask = Task.Run(() =>
                    {
                        return Screen.AllScreens
                            .Select((screen, index) => new MonitorInfo
                            {
                                Name = screen.Primary
                                    ? $"Monitor {index + 1} (Principal)"
                                    : $"Monitor {index + 1}",
                                DeviceName = screen.DeviceName,
                                Primary = screen.Primary
                            })
                            .ToList();
                    }, token);

                    await Task.WhenAll(windowsTask, monitorsTask);

                    var windows = await windowsTask;
                    var monitors = await monitorsTask;

                    if (InvokeRequired)
                    {
                        Invoke(() =>
                        {
                            RefreshWindowsCombo(windows);
                            RefreshMonitorsCombo(monitors);
                        });
                    }
                    else
                    {
                        RefreshWindowsCombo(windows);
                        RefreshMonitorsCombo(monitors);
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        #endregion


        private void FrmRec_DpiChanged(object sender, DpiChangedEventArgs e)
        {

            this.SuspendLayout();

            this.Scale(new SizeF(e.DeviceDpiNew / 96f, e.DeviceDpiNew / 96f));

            this.ResumeLayout();

        }
    }
}
