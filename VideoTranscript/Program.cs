using System.Globalization;
using System.Text;

namespace Transcription
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            // Validação do SPO para garantir que o aplicativo seja executado apenas em sistemas operacionais compatíveis
            if (!OperatingSystem.IsWindowsVersionAtLeast(6, 1))
            {
#pragma warning disable CA1416
                MessageBox.Show("Este aplicativo requer no mínimo Windows 7.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
#pragma warning restore CA1416
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			CultureInfo.DefaultThreadCurrentCulture =  new CultureInfo("pt-BR");

			CultureInfo.DefaultThreadCurrentUICulture =	new CultureInfo("pt-BR");

			ApplicationConfiguration.Initialize();
            Application.Run(new frmAudioTranscription());
		}
	}
}