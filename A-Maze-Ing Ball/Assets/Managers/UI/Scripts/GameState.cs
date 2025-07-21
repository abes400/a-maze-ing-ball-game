using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField]
    Sprite[] starSprites;

    private Image starSpriteImage;

    public TextMeshProUGUI time;
    public static float  timeElapsed;

    private void Start()
    {
        timeElapsed = 0;
        starSpriteImage = GetComponent<Image>();
    }

    private void OnEnable() => GameManager.UpdateStars += UpdateStars;
    private void OnDisable() => GameManager.UpdateStars -= UpdateStars;

    private void Update()
    {
        // Update timer
        timeElapsed += Time.deltaTime;
        time.text = GetTimeCode();
    }

    void UpdateStars(int value) => starSpriteImage.sprite = starSprites[value];

    public static string GetTimeCode()
    {
        int min = Mathf.FloorToInt(timeElapsed / 60);
        int sec = Mathf.FloorToInt(timeElapsed % 60);
        return string.Format("{0:00}:{1:00}", min, sec);
    }
}
