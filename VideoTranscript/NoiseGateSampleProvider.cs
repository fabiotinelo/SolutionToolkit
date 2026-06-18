using NAudio.Wave;
using System;

public class NoiseGateSampleProvider : ISampleProvider
{
    private readonly ISampleProvider source;

    public float OpenThreshold { get; set; } = 0.02f;
    public float CloseThreshold { get; set; } = 0.01f;

    public float Attack { get; set; } = 0.01f;
    public float Release { get; set; } = 0.05f;

    private float envelope = 0;
    private bool gateOpen = false;

    public bool IsClosed => !gateOpen;

    public WaveFormat WaveFormat => source.WaveFormat;

    public NoiseGateSampleProvider(ISampleProvider source)
    {
        this.source = source;
    }

    public int Read(float[] buffer, int offset, int count)
    {
        int samplesRead = source.Read(buffer, offset, count);

        for (int i = 0; i < samplesRead; i++)
        {
            float sample = buffer[offset + i];
            float abs = Math.Abs(sample);

            // envelope follower
            if (abs > envelope)
                envelope += (abs - envelope) * Attack;
            else
                envelope *= (1 - Release);

            // hysteresis
            if (gateOpen)
            {
                if (envelope < CloseThreshold)
                    gateOpen = false;
            }
            else
            {
                if (envelope > OpenThreshold)
                    gateOpen = true;
            }

            // aplicação do gate
            if (!gateOpen)
                buffer[offset + i] = 0;
        }

        return samplesRead;
    }
}