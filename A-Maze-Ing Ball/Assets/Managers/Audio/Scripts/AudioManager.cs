using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioClip BGM;
    [SerializeField] AudioClip[] audios;

    public const short BUTTON = 0, DAMAGE = 1, KEY = 2, MENU_OPEN = 3, ROTATE = 4, STAR = 5, TELEPORT = 6, WIN = 7;
    public static Action<int> PlaySound;

    private void Start()
    {
        musicSource.clip = BGM;
        musicSource.Play();
    }

    private void OnEnable()
    {
        PlaySound += PlaySFX;
        GameManager.TogglePause += OnGamePause;
    }
    private void OnDisable()
    {
        PlaySound -= PlaySFX;
        GameManager.TogglePause -= OnGamePause;
    }

    private void PlaySFX(int audioIndex)
    {
        SFXSource.PlayOneShot(audios[audioIndex]);
    }

    void OnGamePause()
    {
        if (GameManager.isPlaying) musicSource.Play(); else musicSource.Pause();
    }

}
