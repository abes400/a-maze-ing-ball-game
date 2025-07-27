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
        banner.SetActive(!GameManager.isPlaying);
        pauseMenu.SetActive(!GameManager.isPlaying);
    }

    private void OnFinishLevel()
    {
        banner.SetActive(true);
        finishMenu.SetActive(true);
    }

    public void Continue()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.BUTTON);
        GameManager.Unpause();
    }

    public void Restart() => StartCoroutine(LoadSceneWithDelay(SceneManager.GetActiveScene().buildIndex));

    public void Quit() => StartCoroutine(LoadSceneWithDelay());

    public void Next() => StartCoroutine(LoadSceneWithDelay(SceneManager.GetActiveScene().buildIndex + 2)); // Change to 1 on deploy

    private IEnumerator LoadSceneWithDelay(int sceneIndex = -1)
    {
        AudioManager.PlaySound?.Invoke(AudioManager.BUTTON);

        pauseMenu.SetActive(false);
        finishMenu.SetActive(false);
        loadingTitle.SetActive(true);

        yield return new WaitForSecondsRealtime(loadDelay);

        if (sceneIndex == -1) SceneManager.LoadScene("MainMenu");
        else SceneManager.LoadScene(sceneIndex);
    }
}
