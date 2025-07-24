using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, finishMenu, banner;
    // Start is called before the first frame update
    void OnEnable()
    {
        GameManager.TogglePause += OnGamePause;
        GameManager.Finish += OnFinishLevel;
    }

    void OnDisable()
    {
        GameManager.TogglePause -= OnGamePause;
        GameManager.Finish -= OnFinishLevel;
    }

    void OnGamePause()
    {
        banner.SetActive(!GameManager.isPlaying);
        pauseMenu.SetActive(!GameManager.isPlaying);
    }

    public void OnFinishLevel()
    {
        banner.SetActive(true);
        finishMenu.SetActive(true);
    }

    public void Continue() => GameManager.Unpause();

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void Quit() => SceneManager.LoadScene("MainMenu");

    public void Next() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // Change to 1 on deploy
}
