using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [Header("Music")]
    public AudioSource _musicSource;
    public Slider _musicSlider;

    [Header("FX")]
    public AudioSource[] _fxSources;
    public Slider _fxSlider;

    [Header("Master / General")]
    public Slider _masterSlider;

    private float masterVolume = 1f;

    void Start()
    {
        masterVolume = 1f;
        if (_masterSlider != null)
        {
            _masterSlider.value = 0f; 
            _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        }

        if (_musicSlider != null)
        {
            _musicSlider.value = 0f; 
            _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }
        if (_musicSource != null)
            _musicSource.volume = 1f * masterVolume;

        if (_fxSlider != null)
        {
            _fxSlider.value = 0f; 
            _fxSlider.onValueChanged.AddListener(SetFXVolume);
        }
        if (_fxSources != null)
        {
            foreach (var source in _fxSources)
            {
                if (source != null)
                    source.volume = 1f * masterVolume;
            }
        }
        ApplyVolumes();
    }

    void SetMusicVolume(float volume)
    {
        _musicSource.volume = (1f - volume) * masterVolume;
    }

    void SetFXVolume(float volume)
    {
        foreach (AudioSource source in _fxSources)
        {
            source.volume = (1f - volume) * masterVolume;
        }
    }

    void SetMasterVolume(float volume)
    {
        masterVolume = 1f - volume;
        ApplyVolumes();
    }

    void ApplyVolumes()
    {
        SetMusicVolume(_musicSlider.value);
        SetFXVolume(_fxSlider.value);
    }  

}