using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcription
{
	public static class ModelCatalog
	{
		private const string BaseUrl =
			"https://huggingface.co/ggerganov/whisper.cpp/resolve/main/";

		public static readonly Dictionary<string, WhisperModel> Models = CreateModels();

		private static Dictionary<string, WhisperModel> CreateModels()
		{
			var models = new Dictionary<string, WhisperModel>();

			string[] modelNames =
			{
				"tiny",
				"tiny-q5_1",
				"tiny-q8_0",
				"tiny.en",
				"tiny.en-q5_1",
				"tiny.en-q8_0",

				"base",
				"base-q5_1",
				"base-q8_0",
				"base.en",
				"base.en-q5_1",
				"base.en-q8_0",

				"small",
				"small-q5_1",
				"small-q8_0",
				"small.en",
				"small.en-q5_1",
				"small.en-q8_0",
				"small.en-tdrz",

				"medium",
				"medium-q5_0",
				"medium-q8_0",
				"medium.en",
				"medium.en-q5_0",
				"medium.en-q8_0",

				"large-v1",

				"large-v2",
				"large-v2-q5_0",
				"large-v2-q8_0",

				"large-v3",
				"large-v3-q5_0",

				"large-v3-turbo",
				"large-v3-turbo-q5_0",
				"large-v3-turbo-q8_0"
			};

			foreach (var modelName in modelNames)
			{
				var fileName = $"ggml-{modelName}.bin";

				models[modelName] = new WhisperModel
				{
					Name = modelName,
					FileName = fileName,
					DownloadUrl = $"{BaseUrl}{fileName}"
				};
			}

			return models;
		}
	}
}
