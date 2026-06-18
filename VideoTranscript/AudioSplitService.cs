using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;

public class AudioSplitService
{
    // ===== Parâmetros configuráveis =====
    private const int MAX_MINUTES_PER_CHUNK = 10;
    private const int MAX_FILE_SIZE_MB = 25;
    private const int OVERLAP_SECONDS = 5;

    // Whisper exige 16 kHz, mono, PCM 16 bits
    private const int TARGET_SAMPLE_RATE = 16000;
    private const int TARGET_CHANNELS = 1;
    private const int TARGET_BITS_PER_SAMPLE = 16;
    // ====================================

    public List<string> SplitAudio(string inputFile)
    {
        if (!File.Exists(inputFile))
            throw new FileNotFoundException("Arquivo de entrada não encontrado.", inputFile);

        var generatedFiles = new List<string>();

        long maxBytes = (long)MAX_FILE_SIZE_MB * 1024 * 1024;

        // Pasta de saída no mesmo local do arquivo original
        string inputDir = Path.GetDirectoryName(Path.GetFullPath(inputFile))!;
        string baseName = Path.GetFileNameWithoutExtension(inputFile);
        string outputFolder = Path.Combine(inputDir, $"{baseName}_chunks");

        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);

        using var reader = new AudioFileReader(inputFile);

        // Converte para mono + 16 kHz como ISampleProvider
        ISampleProvider mono = reader.WaveFormat.Channels == 1
            ? reader
            : reader.ToSampleProvider().ToMono();

        var resampler = new WdlResamplingSampleProvider(mono, TARGET_SAMPLE_RATE);

        // Formato final dos arquivos: PCM 16 bits, 16 kHz, mono
        var targetFormat = new WaveFormat(TARGET_SAMPLE_RATE, TARGET_BITS_PER_SAMPLE, TARGET_CHANNELS);

        // Se o original já é pequeno o suficiente E está no formato esperado, não corta.
        // Como o Whisper exige formato específico, na dúvida sempre processamos.
        // Mantemos só o early-return quando o arquivo original já é um WAV no formato certo:
        if (IsAlreadyWhisperReady(inputFile, reader.WaveFormat) &&
            new FileInfo(inputFile).Length <= maxBytes)
        {
            Console.WriteLine("Arquivo já está em formato Whisper-ready e dentro do limite. Nenhum corte necessário.");
            generatedFiles.Add(inputFile);
            return generatedFiles;
        }

        int bytesPerSample = TARGET_BITS_PER_SAMPLE / 8; // = 2
        int bytesPerSecond = TARGET_SAMPLE_RATE * TARGET_CHANNELS * bytesPerSample; // = 32.000 bytes/s

        // Limite por tempo (em samples float lidos do resampler)
        long maxSamplesByTime = (long)TARGET_SAMPLE_RATE * TARGET_CHANNELS * 60 * MAX_MINUTES_PER_CHUNK;

        // Limite por tamanho do arquivo final (em samples)
        // Cada sample no .wav final ocupa 2 bytes (16 bits).
        long maxSamplesBySize = (maxBytes - 1024) / bytesPerSample;

        long samplesPerChunk = Math.Min(maxSamplesByTime, maxSamplesBySize);

        long overlapSamples = (long)TARGET_SAMPLE_RATE * TARGET_CHANNELS * OVERLAP_SECONDS;
        if (overlapSamples >= samplesPerChunk)
            overlapSamples = samplesPerChunk / 4;

        var overlapBuffer = new CircularSampleBuffer(overlapSamples);

        float[] buffer = new float[4096];
        int chunkIndex = 1;
        long samplesInCurrentChunk = 0;

        string currentFilePath = BuildChunkPath(outputFolder, baseName, chunkIndex);
        WaveFileWriter writer = new WaveFileWriter(currentFilePath, targetFormat);

        int read;
        while ((read = resampler.Read(buffer, 0, buffer.Length)) > 0)
        {
            int offset = 0;

            while (offset < read)
            {
                long remainingInChunk = samplesPerChunk - samplesInCurrentChunk;
                int toWrite = (int)Math.Min(read - offset, remainingInChunk);
                if (toWrite <= 0) toWrite = 1;

                WriteAsPcm16(writer, buffer, offset, toWrite);
                overlapBuffer.Write(buffer, offset, toWrite);

                samplesInCurrentChunk += toWrite;
                offset += toWrite;

                if (samplesInCurrentChunk >= samplesPerChunk)
                {
                    CloseWriter(writer, currentFilePath);
                    generatedFiles.Add(currentFilePath);

                    chunkIndex++;
                    currentFilePath = BuildChunkPath(outputFolder, baseName, chunkIndex);
                    writer = new WaveFileWriter(currentFilePath, targetFormat);

                    var tail = overlapBuffer.ReadAll();
                    if (tail.Length > 0)
                        WriteAsPcm16(writer, tail, 0, tail.Length);

                    samplesInCurrentChunk = tail.Length;
                }
            }
        }

        CloseWriter(writer, currentFilePath);
        generatedFiles.Add(currentFilePath);

        Console.WriteLine($"Concluído. {generatedFiles.Count} arquivo(s) gerado(s) em: {outputFolder}");
        return generatedFiles;
    }

    /// <summary>
    /// Converte amostras float [-1, 1] para PCM 16 bits e escreve no writer.
    /// </summary>
    private static void WriteAsPcm16(WaveFileWriter writer, float[] samples, int offset, int count)
    {
        // 2 bytes por sample
        byte[] bytes = new byte[count * 2];

        for (int i = 0; i < count; i++)
        {
            float s = samples[offset + i];
            if (s > 1f) s = 1f;
            else if (s < -1f) s = -1f;

            short pcm = (short)(s * short.MaxValue);
            bytes[i * 2] = (byte)(pcm & 0xFF);
            bytes[i * 2 + 1] = (byte)((pcm >> 8) & 0xFF);
        }

        writer.Write(bytes, 0, bytes.Length);
    }

    private static bool IsAlreadyWhisperReady(string file, WaveFormat fmt)
    {
        return file.EndsWith(".wav", StringComparison.OrdinalIgnoreCase)
            && fmt.SampleRate == TARGET_SAMPLE_RATE
            && fmt.Channels == TARGET_CHANNELS
            && fmt.BitsPerSample == TARGET_BITS_PER_SAMPLE
            && fmt.Encoding == WaveFormatEncoding.Pcm;
    }

    private string BuildChunkPath(string folder, string baseName, int index)
        => Path.Combine(folder, $"{baseName}_chunk_{index}.wav");

    private void CloseWriter(WaveFileWriter writer, string filePath)
    {
        writer.Flush();
        writer.Dispose();
        var info = new FileInfo(filePath);
        Console.WriteLine($"Gerado: {filePath} ({info.Length / 1024.0 / 1024.0:F2} MB)");
    }
}

internal class CircularSampleBuffer
{
    private readonly float[] _buffer;
    private readonly long _capacity;
    private long _writePos;
    private long _count;

    public CircularSampleBuffer(long capacity)
    {
        _capacity = Math.Max(0, capacity);
        _buffer = new float[_capacity];
    }

    public void Write(float[] source, int offset, int count)
    {
        if (_capacity == 0) return;

        for (int i = 0; i < count; i++)
        {
            _buffer[_writePos] = source[offset + i];
            _writePos = (_writePos + 1) % _capacity;
            if (_count < _capacity) _count++;
        }
    }

    public float[] ReadAll()
    {
        var result = new float[_count];
        if (_count == 0) return result;

        long start = (_writePos - _count + _capacity) % _capacity;
        for (long i = 0; i < _count; i++)
            result[i] = _buffer[(start + i) % _capacity];

        return result;
    }
}