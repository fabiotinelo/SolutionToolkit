using Whisper.net;

namespace Transcription.Services;

public static class TranscriptionService
{
	public static async Task<string> TranscribeAsync(
		string wavFile,
		string modelPath,
		string language)
	{
		using var factory =
			WhisperFactory.FromPath(modelPath);

		using var processor =
			factory.CreateBuilder()
				.WithLanguage(language)
				.Build();

		using var stream =
			File.OpenRead(wavFile);

		string result = "";

		await foreach (var segment in processor.ProcessAsync(stream))
		{
			result += segment.Text + " ";
		}

		return result;
	}
}