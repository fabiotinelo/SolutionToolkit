namespace Transcription.Services;

public static class ModelDownloader
{
	public static async Task<string> EnsureModelExists(
	WhisperModel model)
	{
		string modelsFolder =
			Path.Combine(
				AppDomain.CurrentDomain.BaseDirectory,
				"Models");

		Directory.CreateDirectory(modelsFolder);

		string modelPath =
			Path.Combine(
				modelsFolder,
				model.FileName);

		if (File.Exists(modelPath))
			return modelPath;

		using HttpClient client = new();

		using var response =
			await client.GetAsync(
				model.DownloadUrl,
				HttpCompletionOption.ResponseHeadersRead);

		response.EnsureSuccessStatusCode();

		await using var stream =
			await response.Content.ReadAsStreamAsync();

		await using var file =
			File.Create(modelPath);

		await stream.CopyToAsync(file);

		return modelPath;
	}
}