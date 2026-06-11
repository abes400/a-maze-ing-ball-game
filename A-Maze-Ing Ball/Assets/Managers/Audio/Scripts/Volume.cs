using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [Header("-----    Child GameObjects (DON'T TOUCH)    -----")]
    [Header("-----    Sliders    -----")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;

    private void OnEnable()
    {
        musicSlider.value = PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 1;
        SFXSlider.value = PlayerPrefs.HasKey("SFXVolume") ? PlayerPrefs.GetFloat("SFXVolume") : 1;
    }

    public void AdjustMusic()
    {
        float value = musicSlider.value;
        audioMixer.SetFloat("music", GetAudioValue(value));
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void AdjustSFX()
    {
        float value = SFXSlider.value;
        audioMixer.SetFloat("sfx", GetAudioValue(value));
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public static float GetAudioValue(float sliderValue) => sliderValue == 0 ? -80 : Mathf.Log10(sliderValue) * 20;
}
