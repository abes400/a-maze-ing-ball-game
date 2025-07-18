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
    float  timeElapsed = 0;

    private void Start()
    {
        starSpriteImage = GetComponent<Image>();
        GameManager.UpdateStars += UpdateStars;
    }

    private void Update()
    {
        // Update timer
        timeElapsed += Time.deltaTime;
        int min = Mathf.FloorToInt(timeElapsed / 60);
        int sec = Mathf.FloorToInt(timeElapsed % 60);
        time.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void UpdateStars(int value) => starSpriteImage.sprite = starSprites[value];
}
