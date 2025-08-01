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

    public const short BUTTON = 0, DAMAGE = 1, KEY = 2, MENU_OPEN = 3, ROTATE = 4, STAR = 5, TELEPORT = 6, WIN = 7;
    public static Action<int> PlaySound;

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

    private void PlaySFX(int audioIndex) => SFXSource.PlayOneShot(audios[audioIndex]);

    void OnGamePause()
    {
        if (GameManager.isPlaying) musicSource.Play(); else musicSource.Pause();
    }

    void OnFinishLevel(bool dummy) => musicSource.Pause();

}
