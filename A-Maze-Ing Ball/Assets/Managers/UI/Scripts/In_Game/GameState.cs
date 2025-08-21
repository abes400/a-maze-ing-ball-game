using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{
    public static float timeElapsed;

    [Header("-----    Child GameObjects (DONT'T TOUCH)    -----")]
    [SerializeField] Sprite[] starSprites;
    [SerializeField] Image starSpriteImage;
    public TextMeshProUGUI time;

    private void Start()
    {
        timeElapsed = 0;
    }

    private void OnEnable() => GameManager.UpdateStars += UpdateStars;
    private void OnDisable() => GameManager.UpdateStars -= UpdateStars;

    private void Update()
    {
        // Update timer
        if (!GameManager.finished)
        {
            timeElapsed += Time.deltaTime;
            time.text = GetTimeCode();
        }
    }

    private void UpdateStars(int value) => starSpriteImage.sprite = starSprites[value];

    public static string GetTimeCode(float timeOverride = -1)
    {
        if (timeOverride == -1) timeOverride = timeElapsed;
        int min = Mathf.FloorToInt(timeOverride / 60);
        int sec = Mathf.FloorToInt(timeOverride % 60);
        return string.Format("{0:00}:{1:00}", min, sec);
    }
}
