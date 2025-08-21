using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishStat : MonoBehaviour
{
    [SerializeField] Sprite[] starSprites;
    
    [Header("-----    Child GameObjects (DONT'T TOUCH)    -----")]
    [SerializeField] TextMeshProUGUI timeStat;

    private void Start()
    {
        GetComponent<Image>().sprite = starSprites[GameManager.collectedStars];
        timeStat.text = GameState.GetTimeCode();
    }
}
