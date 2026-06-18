using System.Runtime.CompilerServices;
using System.Text;
using Whisper.net;

namespace Transcription.Services;

public sealed class TranscriptionService : IDisposable
{
    private readonly WhisperFactory _factory;
    private readonly string _language;

    public TranscriptionService(string modelPath, string language)
    {
        _factory = WhisperFactory.FromPath(modelPath);
        _language = language;
    }

    // ====== MÉTODOS EXISTENTES (inalterados) ======

    public async Task<string> TranscribeAsync(
        string wavFile,
        CancellationToken cancellationToken = default)
    {
        using var processor = _factory.CreateBuilder()
            .WithLanguage(_language)
            .Build();

        using var stream = File.OpenRead(wavFile);

        var sb = new StringBuilder();

        await foreach (var segment in processor.ProcessAsync(stream, cancellationToken))
        {
            sb.Append(segment.Text).Append(' ');
        }

        return sb.ToString().Trim();
    }

    public async Task<string> TranscribeManyAsync(
        IEnumerable<string> wavFiles,
        IProgress<TranscriptionProgress>? progress = null,
        CancellationToken cancellationToken = default)
    {
        var files = wavFiles.ToList();
        var finalText = new StringBuilder();

        for (int i = 0; i < files.Count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var file = files[i];
            progress?.Report(new TranscriptionProgress(i + 1, files.Count, file));

            var text = await TranscribeAsync(file, cancellationToken);

            if (finalText.Length > 0) finalText.Append(' ');
            finalText.Append(text);
        }

        return finalText.ToString().Trim();
    }

    public async Task<List<TranscriptionResult>> TranscribeEachAsync(
        IEnumerable<string> wavFiles,
        IProgress<TranscriptionProgress>? progress = null,
        CancellationToken cancellationToken = default)
    {
        var files = wavFiles.ToList();
        var results = new List<TranscriptionResult>(files.Count);

        for (int i = 0; i < files.Count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var file = files[i];
            progress?.Report(new TranscriptionProgress(i + 1, files.Count, file));

            var text = await TranscribeAsync(file, cancellationToken);
            results.Add(new TranscriptionResult(file, text));
        }

        return results;
    }

    // ====== NOVOS MÉTODOS DE STREAMING ======

    /// <summary>
    /// Transcreve UM arquivo WAV e devolve cada segmento de texto assim que o Whisper o produz.
    /// Ideal para mostrar o texto aparecendo em tempo real na UI.
    /// </summary>
    public async IAsyncEnumerable<TranscriptionSegment> TranscribeStreamAsync(
        string wavFile,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var processor = _factory.CreateBuilder()
            .WithLanguage(_language)
            .Build();

        using var stream = File.OpenRead(wavFile);

        await foreach (var segment in processor.ProcessAsync(stream, cancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new TranscriptionSegment(
                File: wavFile,
                Text: segment.Text,
                Start: segment.Start,
                End: segment.End);
        }
    }

    /// <summary>
    /// Transcreve VÁRIOS arquivos WAV e devolve cada segmento (com o arquivo de origem),
    /// preservando a ordem. Permite "streamar" tudo na UI sem esperar nenhum arquivo terminar.
    /// </summary>
    public async IAsyncEnumerable<TranscriptionSegment> TranscribeManyStreamAsync(
        IEnumerable<string> wavFiles,
        IProgress<TranscriptionProgress>? progress = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var files = wavFiles.ToList();

        for (int i = 0; i < files.Count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var file = files[i];
            progress?.Report(new TranscriptionProgress(i + 1, files.Count, file));

            await foreach (var seg in TranscribeStreamAsync(file, cancellationToken))
            {
                yield return seg;
            }
        }
    }

    public void Dispose()
    {
        _factory.Dispose();
    }
}

public record TranscriptionProgress(int Current, int Total, string CurrentFile);
public record TranscriptionResult(string File, string Text);
public record TranscriptionSegment(string File, string Text, TimeSpan Start, TimeSpan End);