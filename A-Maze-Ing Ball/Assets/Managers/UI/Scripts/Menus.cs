using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, finishMenu;
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

    void OnGamePause() => pauseMenu.SetActive(!GameManager.isPlaying);

    public void OnFinishLevel() => finishMenu.SetActive(true);

    public void Continue() => GameManager.Unpause();

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void Quit() => SceneManager.LoadScene("MainMenu");

    public void Next() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // Change to 1 on deploy
}
