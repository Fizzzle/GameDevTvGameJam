using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, soundSlider;

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundEffectsMixerGroup;

    private const string MUSIC_VOL_KEY = "musicVol";
    private const string SOUND_VOL_KEY = "soundVol";

    private void Awake()
    {
        Load();
        SetMixerLevels();
    }

    public void OnMusicSliderValueChange()
    {
        ChangeVolume();
    }

    public void OnSoundEffectsSliderValueChange()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        float musicVolume = musicSlider.value;
        float soundVolume = soundSlider.value;

        musicMixerGroup.audioMixer.SetFloat("musicVolume", musicVolume);
        soundEffectsMixerGroup.audioMixer.SetFloat("soundVolume", soundVolume);

        Save();
    }

    private void SetMixerLevels()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_VOL_KEY, 1f);
        float soundVolume = PlayerPrefs.GetFloat(SOUND_VOL_KEY, 1f);

        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;

        musicMixerGroup.audioMixer.SetFloat("musicVolume", musicVolume);
        soundEffectsMixerGroup.audioMixer.SetFloat("soundVolume", soundVolume);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(MUSIC_VOL_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(SOUND_VOL_KEY, soundSlider.value);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(MUSIC_VOL_KEY))
        {
            PlayerPrefs.SetFloat(MUSIC_VOL_KEY, 1f);
        }

        if (!PlayerPrefs.HasKey(SOUND_VOL_KEY))
        {
            PlayerPrefs.SetFloat(SOUND_VOL_KEY, 1f);
        }
    }
}
