using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenus : MonoBehaviour
{
    [SerializeField] int levelCount;
    [SerializeField] GameObject levelButtonPrefab;
    [SerializeField] GameObject logo;
    [SerializeField] GameObject byLine;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject instructionsMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject aboutMenu;
    [SerializeField] GameObject resetPopup;
    [SerializeField] GameObject quitPopup;
    [SerializeField] GameObject contentOfLevelView;

    public void Start()
    {
        int unlockedUpto = PlayerPrefs.GetInt("Unlocked_Upto");
        if (unlockedUpto == 0)
        {
            PlayerPrefs.SetInt("Unlocked_Upto", 1);
            unlockedUpto = 1;
        }

        for (int index = 1; index <= levelCount; index++)
        {
            GameObject newLevelButton = Instantiate(levelButtonPrefab, contentOfLevelView.transform);
            newLevelButton.GetComponent<LevelButton>().InitButton(index, unlockedUpto);
        }
    }
    public void GameStart()
    {
        MainMenuSetActive(false);
        levelMenu.SetActive(true);
    }

    public void Instructions()
    {
        MainMenuSetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void Options()
    {
        MainMenuSetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ConfirmReset()
    {
        optionsMenu.SetActive(false);
        resetPopup.SetActive(true); 
    }

    public void AbortReset()
    {
        resetPopup.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Reset()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void About()
    {
        MainMenuSetActive(false);
        aboutMenu.SetActive(true);
    }

    public void ConfirmQuit()
    {
        MainMenuSetActive(false);
        quitPopup.SetActive(true);
    }

    public void Back()
    {
        levelMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        aboutMenu.SetActive(false);
        quitPopup.SetActive(false);

        MainMenuSetActive(true);
    }

    public void Quit() => Application.Quit(0);


    private void MainMenuSetActive(bool active)
    {
        logo.SetActive(active);
        byLine.SetActive(active);
        mainMenu.SetActive(active);
    }
}
