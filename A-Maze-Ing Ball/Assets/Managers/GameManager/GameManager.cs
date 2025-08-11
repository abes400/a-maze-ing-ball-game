using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static bool isPlaying, finished;
    public static int collectedStars, levelIndex;

    public static Action<int> UpdateStars;
    public static Action<bool> Finish;
    public static Action Fail;
    public static Action TogglePause;

    [SerializeField] int thisLevelIndex;

    private void Start()
    {
        Time.timeScale = 1;
        isPlaying = true;
        finished = false;
        collectedStars = 0;
        levelIndex = thisLevelIndex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !finished)
        {
            if (isPlaying) PauseLevel(); else Unpause();
        } else if (Input.GetKeyDown(KeyCode.Backspace) && !finished)
        {
            FailLevel();
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
        
        PlayerPrefs.SetInt($"Level_{levelIndex}_STAR", collectedStars);
        PlayerPrefs.SetFloat($"Level_{levelIndex}_TIME", GameState.timeElapsed);
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
