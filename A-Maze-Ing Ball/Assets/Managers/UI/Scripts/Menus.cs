using System.Collections;
using System.Collections.Generic;
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

    void OnGamePause()
    {
        pauseMenu.SetActive(!GameManager.isPlaying);
    }

    public void OnFinishLevel(int stars, string timeCode)
    {
        //
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        GameManager.Unpause();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit(bool saveData = false)
    {
        if (saveData) Debug.Log("TODO: Save Data");
        SceneManager.LoadScene("MainMenu");
    }
}
