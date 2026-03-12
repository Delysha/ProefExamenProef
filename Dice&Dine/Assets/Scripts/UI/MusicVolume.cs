using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public AudioSource _musicSource;
    public Slider _volumeSlider;

    void Start()
    {
        _volumeSlider.value = _musicSource.volume;
        _volumeSlider.onValueChanged.AddListener(SetVolume);
    }
    
    void SetVolume(float volume)
    {
        _musicSource.volume =1f - volume;
    }

}
