using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishStat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeStat;
    [SerializeField] Sprite[] starSprites;

    private void Start()
    {
        GetComponent<Image>().sprite = starSprites[GameManager.collectedStars];
        timeStat.text = GameState.GetTimeCode();
    }
}
