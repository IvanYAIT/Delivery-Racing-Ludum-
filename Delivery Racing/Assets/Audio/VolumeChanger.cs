using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        sfxSlider.value = AudioSingleton.Instance().sfxVolume;
        musicSlider.value = AudioSingleton.Instance().musicVolume;
        masterSlider.value = AudioSingleton.Instance().masterVolume;
    }

    public void SetMusic()
    {
        AudioSingleton.Instance().musicVolume = musicSlider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(AudioSingleton.Instance().musicVolume) * 20);
        if(AudioSingleton.Instance().musicVolume == 0)
            audioMixer.SetFloat("Music", -20);
    }

    public void SetSFX()
    {
        AudioSingleton.Instance().sfxVolume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(AudioSingleton.Instance().sfxVolume) * 20);
        if (AudioSingleton.Instance().sfxVolume == 0)
            audioMixer.SetFloat("SFX", -20);
    }

    public void SetMaster()
    {
        AudioSingleton.Instance().masterVolume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(AudioSingleton.Instance().masterVolume) * 20);
        if (AudioSingleton.Instance().masterVolume == 0)
            audioMixer.SetFloat("Master", -20);
    }
}
