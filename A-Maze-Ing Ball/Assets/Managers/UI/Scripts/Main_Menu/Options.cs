using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject fullScreenButton;
    [SerializeField] GameObject resCalButton;

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        fullScreenButton.GetComponentInChildren<TextMeshProUGUI>().text
            = $"Fullscreen: {(Screen.fullScreen ? "ON" : "OFF")}";
    }

    public void CalibrateRes()
    {
        
    }
}
