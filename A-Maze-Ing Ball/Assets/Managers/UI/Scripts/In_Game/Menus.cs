using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    [SerializeField] float loadDelay = 0.5f;
    // Start is called before the first frame update

    [Header("-----    Child GameObjects (DONT'T TOUCH)    -----")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject finishMenu;
    [SerializeField] GameObject failMenu;
    [SerializeField] GameObject banner;
    [SerializeField] GameObject loadingTitle;
    private void OnEnable()
    {
        GameManager.TogglePause += OnGamePause;
        GameManager.Finish += OnFinishLevel;
    }

    private void OnDisable()
    {
        GameManager.TogglePause -= OnGamePause;
        GameManager.Finish -= OnFinishLevel;
    }

    private void OnGamePause()
    {
        if (!GameManager.isPlaying) AudioManager.PlaySound?.Invoke(AudioManager.SFXName.MENU_OPEN);
        banner.SetActive(!GameManager.isPlaying);
        pauseMenu.SetActive(!GameManager.isPlaying);
        SetCursorLocked(GameManager.isPlaying);
    }

    private void OnFinishLevel(bool succeeded) => StartCoroutine(FinishSceneWithDelay(succeeded));
    private IEnumerator FinishSceneWithDelay(bool succeeded)
    {
        yield return new WaitForSecondsRealtime(loadDelay);

        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.MENU_OPEN);

        banner.SetActive(true);
        if (succeeded) finishMenu.SetActive(true);
        else failMenu.SetActive(true);
        SetCursorLocked(false);
    }

    public void Continue()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.BUTTON);
        GameManager.Unpause();
    }

    public void Restart() => StartCoroutine(LoadSceneWithDelay(SceneManager.GetActiveScene().name));

    public void Quit() => StartCoroutine(LoadSceneWithDelay());

    public void Next() => StartCoroutine(LoadSceneWithDelay($"Level_{GameManager.levelIndex + 1}"));

    private IEnumerator LoadSceneWithDelay(string sceneName = "MainMenu")
    {
        GameManager.loading = true;
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.BUTTON);

        pauseMenu.SetActive(false);
        finishMenu.SetActive(false);
        failMenu.SetActive(false);
        loadingTitle.SetActive(true);

        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(sceneName);
    }
    
    public static void SetCursorLocked(bool locked) => Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;

}
