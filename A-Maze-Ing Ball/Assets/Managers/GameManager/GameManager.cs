using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static bool isPlaying, finished;
    public static int collectedStars;

    public static Action<int> UpdateStars;
    public static Action Finish;
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
        if (Input.GetKeyDown(KeyCode.Escape) && !finished)
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
        AudioManager.PlaySound?.Invoke(AudioManager.MENU_OPEN);
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
        // save game
        isPlaying = false;
        finished = true;
        Finish?.Invoke();
        Debug.Log(string.Format("Level finished with {0} stars in {1} seconds", collectedStars, GameState.GetTimeCode()));
        AudioManager.PlaySound?.Invoke(AudioManager.MENU_OPEN);
    }
}
