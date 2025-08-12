using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenus : MonoBehaviour
{
    [SerializeField] int levelCount;
    [SerializeField] AudioManager audioManager;
    [SerializeField] GameObject levelButtonPrefab;
    [SerializeField] GameObject logoBase;
    [SerializeField] GameObject menuBase;
    [SerializeField] GameObject byLine;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject instructionsMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject aboutMenu;
    [SerializeField] GameObject resetPopup;
    [SerializeField] GameObject quitPopup;
    [SerializeField] GameObject contentOfLevelView;

    private void Start()
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (resetPopup.activeInHierarchy)
                AbortReset();
            else if (!mainMenu.activeInHierarchy)
                Back();
            else
                ConfirmQuit();
        }
            
    }
    public void GameStart()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.MENU_OPEN);
        MainMenuSetActive(false);
        levelMenu.SetActive(true);
    }

    public void Instructions()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.MENU_OPEN);
        MainMenuSetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void Options()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.MENU_OPEN);
        MainMenuSetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ConfirmReset()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.BUTTON);
        optionsMenu.SetActive(false);
        resetPopup.SetActive(true); 
    }

    public void AbortReset()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.MENU_OPEN);
        resetPopup.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Reset()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.BUTTON);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void About()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.MENU_OPEN);
        MainMenuSetActive(false);
        aboutMenu.SetActive(true);
    }

    public void ConfirmQuit()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.BUTTON);
        MainMenuSetActive(false);
        quitPopup.SetActive(true);
    }

    public void Back()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.SFXName.TELEPORT);
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
        logoBase.SetActive(active);
        menuBase.SetActive(!active);
        byLine.SetActive(active);
        mainMenu.SetActive(active);
    }
}
