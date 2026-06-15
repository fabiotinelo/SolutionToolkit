using Microsoft.VisualBasic;
using NAudio.Wave;

namespace Transcription.Services;

public static class AudioConverter
{
	public static string ConvertTo16KhzMono(string sourceFile)
	{
		string outputFile =
		   Path.Combine(
			   Path.GetTempPath(),
			   $"{Guid.NewGuid()}.wav");

		using var reader =
			new MediaFoundationReader(sourceFile);

		var targetFormat =
			new WaveFormat(
				rate: 16000,
				bits: 16,
				channels: 1);

		using var resampler =
			new MediaFoundationResampler(
				reader,
				targetFormat);

		resampler.ResamplerQuality = 60;

		WaveFileWriter.CreateWaveFile(
			outputFile,
			resampler);

		return outputFile;
	}
}