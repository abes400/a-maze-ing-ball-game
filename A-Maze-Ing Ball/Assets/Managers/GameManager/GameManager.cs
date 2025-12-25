using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPlaying, finished, loading = false;
    public static int collectedStars, levelIndex;
    public static string levelName;

    public static Action<int> UpdateStars;
    public static Action<bool> Finish;
    public static Action Fail, TogglePause, RestartKey;


    private void Start()
    {
        loading = true;
        Time.timeScale = 1;
        isPlaying = true;
        finished = false;
        collectedStars = 0;
        levelName = SceneManager.GetActiveScene().name;
        levelIndex = int.Parse(levelName.Split('_')[1]);
        Menus.SetCursorLocked(true);
        loading = false;

    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape) && !finished && !loading)
        {
            if (isPlaying) PauseLevel(); else Unpause();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) && !finished)
        {
            FailLevel();
        }
        */
        
        if(!loading) // In-game
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !finished)
                if(isPlaying) PauseLevel();
                else Unpause();
            else if (Input.GetKeyDown(KeyCode.R))
            {
                isPlaying = false;
                Time.timeScale = 0;
                RestartKey?.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Backspace)) FailLevel(); // For debug only, delete when game finishes
        }
    }

    public static void OnStarCollected(int incrementSize)
    {
        collectedStars += incrementSize;

        if (collectedStars < 0) FailLevel();
        else UpdateStars?.Invoke(collectedStars);
    }

    public static void PauseLevel()
    {
        isPlaying = false;
        Time.timeScale = 0;
        TogglePause?.Invoke();
    }

    public static void Unpause()
    {
        isPlaying = true;
        Time.timeScale = 1;
        TogglePause?.Invoke();
    }

    public static void FinishLevel()
    {
        isPlaying = false;
        finished = true;

        PlayerPrefs.SetInt($"{levelName}_STAR", collectedStars);
        PlayerPrefs.SetFloat($"{levelName}_TIME", GameState.timeElapsed);
        if (PlayerPrefs.GetInt("Unlocked_Upto") == levelIndex)
            PlayerPrefs.SetInt("Unlocked_Upto", levelIndex + 1);
        PlayerPrefs.Save();

        Finish?.Invoke(true);
        //Debug.Log(string.Format("Level finished with {0} stars in {1} seconds", collectedStars, GameState.GetTimeCode()));

    }

    public static void FailLevel()
    {
        isPlaying = false;
        finished = true;
        Finish?.Invoke(false);
    }
}
