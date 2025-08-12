using System;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] GameObject fullScreenButton;
    TextMeshProUGUI buttonText;

    void OnEnable()
    {
        buttonText = fullScreenButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = $"Fullscreen: {(Screen.fullScreen ? "ON" : "OFF")}";
    }

    public void ToggleFullScreen()
    {
        bool fullScreenEnabled = !Screen.fullScreen;
        int newWidth, newHeight;
        FullScreenMode newFSMode;

        if (fullScreenEnabled)
        {
            newWidth = Display.main.systemWidth;
            newHeight = Display.main.systemHeight;
            newFSMode = FullScreenMode.FullScreenWindow;
            buttonText.text = "Fullscreen: ON";
        }
        else
        {
            newWidth = (int)(Display.main.systemWidth * 0.8f);
            newHeight = (int)(Display.main.systemHeight * 0.8f);
            newFSMode = FullScreenMode.Windowed;
            buttonText.text = "Fullscreen: OFF";
        }

        Screen.SetResolution(newWidth, newHeight, newFSMode);
        PlayerPrefs.SetInt("Fullscreen", fullScreenEnabled ? 1 : 0);
        PlayerPrefs.Save();

    }
}
