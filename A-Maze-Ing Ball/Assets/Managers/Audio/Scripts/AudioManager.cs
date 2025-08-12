using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [SerializeField] AudioClip BGM;
    [SerializeField] AudioClip[] audios;

    public enum SFXName { BUTTON, MENU_OPEN, DAMAGE, KEY, ROTATE, STAR, TELEPORT, WIN };
    public static Action<SFXName> PlaySound;

    private void Start()
    {
        audioMixer.SetFloat("music", Volume.GetAudioValue(PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 1));
        audioMixer.SetFloat("sfx", Volume.GetAudioValue(PlayerPrefs.HasKey("SFXVolume") ? PlayerPrefs.GetFloat("SFXVolume") : 1));
        musicSource.clip = BGM;
        musicSource.Play();
    }

    private void OnEnable()
    {
        PlaySound += PlaySFX;
        GameManager.TogglePause += OnGamePause;
        GameManager.Finish += OnFinishLevel;
    }
    private void OnDisable()
    {
        PlaySound -= PlaySFX;
        GameManager.TogglePause -= OnGamePause;
        GameManager.Finish -= OnFinishLevel;
    }

    private void PlaySFX(SFXName audioIndex) => SFXSource.PlayOneShot(audios[(int) audioIndex]);

    void OnGamePause()
    {
        if (GameManager.isPlaying) musicSource.Play(); else musicSource.Pause();
    }

    void OnFinishLevel(bool dummy) => musicSource.Pause();

}
