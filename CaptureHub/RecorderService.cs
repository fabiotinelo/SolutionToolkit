using ScreenRecorderLib;

namespace Rec
{
	public sealed class RecorderService : IDisposable
	{
		private Recorder? _recorder;
		private bool _recording;

		public bool IsRecording => _recording;

		public async Task StartAsync(
									string outputFile,
									IntPtr? windowHandle = null,
									string? monitorDeviceName = null)
		{
			if (_recording)
				return;

			RecorderOptions options = RecorderOptions.DefaultMainMonitor;

			if (windowHandle.HasValue)
			{
				options.SourceOptions.RecordingSources.Clear();

				options.SourceOptions.RecordingSources.Add(
					new WindowRecordingSource(windowHandle.Value));
			}
			else if (!string.IsNullOrWhiteSpace(monitorDeviceName))
			{
				options.SourceOptions.RecordingSources.Clear();

				options.SourceOptions.RecordingSources.Add(
					new DisplayRecordingSource(monitorDeviceName));
			}

			// VIDEO
			options.VideoEncoderOptions.Framerate = 30;
			options.VideoEncoderOptions.Quality = 90;
			options.VideoEncoderOptions.Bitrate = 8_000_000;

			options.VideoEncoderOptions.IsFixedFramerate = true;
			options.VideoEncoderOptions.IsHardwareEncodingEnabled = true;
			options.VideoEncoderOptions.IsMp4FastStartEnabled = true;

			// AUDIO
			options.AudioOptions.IsAudioEnabled = true;
			options.AudioOptions.IsOutputDeviceEnabled = true;
			options.AudioOptions.IsInputDeviceEnabled = true;

			_recorder = Recorder.CreateRecorder(options);

			_recorder.Record(outputFile);

			_recording = true;

			await Task.CompletedTask;
		}

		public async Task StopAsync()
		{
			if (!_recording || _recorder == null)
				return;

			var tcs = new TaskCompletionSource();

			_recorder.OnRecordingComplete += (_, _) =>
			{
				tcs.TrySetResult();
			};

			_recorder.Stop();

			await tcs.Task;

			_recording = false;
		}

		public void Dispose()
		{
			try
			{
				if (_recorder != null)
				{
					var recorder = _recorder;
					_recorder = null;

					recorder.Dispose();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
