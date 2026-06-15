using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcription
{
	public class WhisperModel
	{
		public required string Name { get; set; }
		public required string FileName { get; set; }
		public required string DownloadUrl { get; set; }
	}
}
