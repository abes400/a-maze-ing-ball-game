using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI lockedText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Image starSpriteImage;
    [SerializeField] Sprite[] starSprites;

    public void InitButton(int level, int unlockedUpto)
    {
        levelText.text = level.ToString();
        bool unlockable = level <= unlockedUpto;
        timeText.enabled = starSpriteImage.enabled = GetComponent<Button>().interactable = unlockable;
        lockedText.enabled = !unlockable;
        if (unlockable)
        {
            timeText.text =
                PlayerPrefs.HasKey($"Level_{level}_TIME") ?
                GameState.GetTimeCode(PlayerPrefs.GetFloat($"Level_{level}_TIME")) :
                "- New -";
            starSpriteImage.sprite =
                starSprites[
                    PlayerPrefs.HasKey($"Level_{level}_TIME") ?
                    PlayerPrefs.GetInt($"Level_{level}_STAR") :
                    0
                ];
        }
    }
}
