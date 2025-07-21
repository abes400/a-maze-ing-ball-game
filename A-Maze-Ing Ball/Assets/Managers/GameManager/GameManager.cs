using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static bool isPlaying, finished;
    static int collectedStars;

    public static Action<int> UpdateStars;
    public static Action<int, string> Finish;
    public static Action TogglePause;

    private void Start()
    {
        Time.timeScale = 1;
        isPlaying = true;
        finished = false;
        collectedStars = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPlaying) PauseLevel(); else Unpause();
        }
    }

    public static void OnStarCollected(int incrementSize)
    {
        collectedStars += incrementSize;
        UpdateStars?.Invoke(collectedStars);
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
        Finish?.Invoke(collectedStars, GameState.GetTimeCode());
        Debug.Log(string.Format("Level finished with {0} stars in {1} seconds", collectedStars, GameState.GetTimeCode()));
    }
}
