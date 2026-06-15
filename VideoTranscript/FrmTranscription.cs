using Microsoft.VisualBasic;
using Transcription.Services;

namespace Transcription
{
	public partial class frmAudioTranscription : Form
	{
		public frmAudioTranscription()
		{
			InitializeComponent();
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

				string wavFile = AudioConverter.ConvertTo16KhzMono(dialog.FileName);

				tslStatus.Text =
					"Transcrevendo...";

				Application.DoEvents();

				string language = cmbLanguage.SelectedItem.ToString()!;
				
				string text =
					await TranscriptionService
						.TranscribeAsync(
							wavFile,
							modelPath,
							language);

				txtResult.Text = text;

				tslStatus.Text =
					"Concluído";

				try
				{
					if (File.Exists(wavFile))
						File.Delete(wavFile);
				}
				catch
				{
					// ignora erro de limpeza
				}
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

		private async void button2_Click(object sender, EventArgs e)
		{

		
		}

	

		
	}
}
