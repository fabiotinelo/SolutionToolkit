using AudioSwitcher.AudioApi.CoreAudio;
using System.Linq;

public class MicrophoneController
{
    private readonly CoreAudioController _controller = new CoreAudioController();

    private CoreAudioDevice GetDefaultMic()
    {
        return _controller.GetCaptureDevices().FirstOrDefault(d => d.IsDefaultDevice);
    }

    public void SetMicrophoneMute(bool mute)
    {
        var mic = GetDefaultMic();
        if (mic != null)
        {
            mic.Mute(mute);
        }
    }

    public void ToggleMicrophone()
    {
        var mic = GetDefaultMic();
        if (mic != null)
        {
            mic.Mute(!mic.IsMuted);
        }
    }

    public bool IsMuted()
    {
        var mic = GetDefaultMic();
        return mic?.IsMuted ?? false;
    }
}