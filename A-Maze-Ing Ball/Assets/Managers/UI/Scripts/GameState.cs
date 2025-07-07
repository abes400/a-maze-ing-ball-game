using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public TextMeshProUGUI starCount;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.UpdateStars += UpdateStars;
        starCount.text = "0";
    }

    void UpdateStars(int value)
    {
        starCount.text = value.ToString();
    }
}
