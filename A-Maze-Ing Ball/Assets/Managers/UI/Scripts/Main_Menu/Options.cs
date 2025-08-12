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
        buttonText.text = $"Fullscreen: {(fullScreenEnabled ? "ON" : "OFF")}";
        SetFullScreen(fullScreenEnabled);
    }

    public static void SetFullScreen(bool fullScreenEnabled)
    {
        int newWidth, newHeight;
        FullScreenMode newFSMode;

        if (fullScreenEnabled)
        {
            newWidth = Display.main.systemWidth;
            newHeight = Display.main.systemHeight;
            newFSMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            newWidth = (int)(Display.main.systemWidth * 0.8f);
            newHeight = (int)(Display.main.systemHeight * 0.8f);
            newFSMode = FullScreenMode.Windowed;
        }

        Screen.SetResolution(newWidth, newHeight, newFSMode);
        PlayerPrefs.SetInt("Fullscreen", fullScreenEnabled ? 1 : 0);
    }
}
