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