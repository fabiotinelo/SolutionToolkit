using Microsoft.VisualBasic;
using System.Formats.Tar;
using Transcription.Services;

namespace Transcription
{
    public partial class frmAudioTranscription : Form
    {

        private string wavFile;
        private List<string> chunks;

        public frmAudioTranscription()
        {
            InitializeComponent();
        }
        
        private void frmAudioTranscription_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteTempFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = $"{this.Text} - v{Application.ProductVersion}";
            this.WindowState = FormWindowState.Maximized;
            cbbModel.SelectedIndex = 12;
            cmbLanguage.SelectedIndex = 0;
            txtResult.Dock = DockStyle.Fill;
            pnlResult.Dock = DockStyle.Fill;
        }

        // Método para deletar arquivos temporários, se necessário
        private void DeleteTempFiles()
        {
            List<string> filesRemove = new List<string>();
            if (wavFile != null) filesRemove.Add(wavFile);
            if (chunks != null) filesRemove.AddRange(chunks);

            foreach (var f in filesRemove)
            {
                if (File.Exists(f))
                {
                    try
                    {
                        File.Delete(f);
                    }
                    catch (Exception) { continue; }
                }

            }
        }


        private async void btnCopyText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtResult.Text))
            {
                Clipboard.SetText(txtResult.Text);
                MessageBox.Show(
                    "Texto copiado para a área de transferência.",
                    "Cópia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {



            try
            {
                if (cbbModel.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Selecione um modelo.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cmbLanguage.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Selecione um idioma.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using OpenFileDialog dialog = new();

                dialog.Title = "Selecione um arquivo de mídia";

                dialog.Filter =
                    "Arquivos de mídia|" +
                    "*.mp3;*.wav;*.m4a;*.aac;*.mp4;*.wmv|" +
                    "Todos os arquivos|*.*";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                tslFilePath.Text = dialog.FileName;

                btnTranscribe.Enabled = false;

                Cursor = Cursors.WaitCursor;

                txtResult.Clear();

                tslStatus.Text = "Preparando...";

                Application.DoEvents();

                string selectedModel =
                    cbbModel.SelectedItem.ToString()!;

                var model =
                    ModelCatalog.Models[selectedModel];

                tslStatus.Text =
                    $"Verificando modelo {selectedModel}...";

                Application.DoEvents();


                string modelPath =
                    await ModelDownloader
                        .EnsureModelExists(model);

                tslStatus.Text =
                    "Convertendo mídia para WAV...";

                Application.DoEvents();


                wavFile = AudioConverter.ConvertTo16KhzMono(dialog.FileName);


                //dividir arquivo
                var audioSplitService = new AudioSplitService();
                chunks = audioSplitService.SplitAudio(wavFile);


                tslStatus.Text =
                    "Transcrevendo...";

                Application.DoEvents();

                //Realiza a transcrição dos chunks
                string language = cmbLanguage.SelectedItem.ToString()!;
                using var transcriber = new TranscriptionService(
                    modelPath: modelPath,
                    language: language);

                /*
                var progress = new Progress<TranscriptionProgress>(p => Console.WriteLine($"[{p.Current}/{p.Total}] Transcrevendo: {Path.GetFileName(p.CurrentFile)}"));
                //Tudo concatenado em uma string final
                string textoCompleto = await transcriber.TranscribeManyAsync(chunks, progress);

				Application.DoEvents();

                txtResult.Text = textoCompleto;

				*/

                //********	****	****	****	****	****	****	****	****	****	****		

                var progress = new Progress<TranscriptionProgress>(p =>
                {
                    tslStatus.Text = $"Transcrevendo {p.Current}/{p.Total}: {Path.GetFileName(p.CurrentFile)}";
                });


                string? arquivoAtual = null;

                await foreach (var seg in transcriber.TranscribeManyStreamAsync(chunks, progress))
                {
                    // Quando muda de arquivo, pula linha para separar visualmente
                    if (seg.File != arquivoAtual)
                    {
                        if (arquivoAtual != null) txtResult.AppendText(Environment.NewLine + Environment.NewLine);
                        arquivoAtual = seg.File;
                    }

                    Application.DoEvents();
                    txtResult.AppendText(seg.Text + " ");

                    //Mover a barra de rolagem para baixo para acompanhar o texto que vai sendo adicionado
                    txtResult.SelectionStart = txtResult.TextLength;
                    txtResult.SelectionLength = 0;
                    txtResult.ScrollToCaret();

                }

                //********	****	****	****	****	****	****	****	****	****	****	


                Application.DoEvents();

                tslStatus.Text =
                    "Concluído";

            }
            catch (Exception ex)
            {
                tslStatus.Text = "Erro";

                MessageBox.Show(
                    ex.ToString(),
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnTranscribe.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


       
    }
}
