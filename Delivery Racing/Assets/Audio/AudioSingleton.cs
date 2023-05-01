public class AudioSingleton
{
    public float sfxVolume;
    public float musicVolume;
    public float masterVolume;

    private static AudioSingleton instance;

    private AudioSingleton() { }

    public static AudioSingleton Instance()
    {
        if (instance == null)
            instance = new AudioSingleton() { masterVolume= 1, musicVolume = 1, sfxVolume= 1};
        return instance;
    }
}
