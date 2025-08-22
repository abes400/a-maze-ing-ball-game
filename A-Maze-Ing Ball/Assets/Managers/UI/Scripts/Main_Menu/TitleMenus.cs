using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenus : MonoBehaviour
{
    [Header("-----    General Settings    -----")]
    [SerializeField] int levelCount;
    [SerializeField] float loadDelay = 0.5f;

    [Header("-----    Child GameObjects (DONT'T TOUCH)    -----")]

    [Header("-----    UI Elements    -----")]
    [SerializeField] GameObject logoBase;
    [SerializeField] GameObject menuBase;
    [SerializeField] GameObject byLine;
    [SerializeField] GameObject quitButton;

    [Header("-----    Menu Objects    -----")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject instructionsMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject aboutMenu;

    [Header("-----    Popup Objects    -----")]
    [SerializeField] GameObject resetPopup;
    [SerializeField] GameObject quitPopup;

    [Header("-----    Level Menu Objects    -----")]
    [SerializeField] GameObject levelButtonPrefab;
    [SerializeField] GameObject contentOfLevelView;

    [Header("")]
    [SerializeField] GameObject loadingBanner;

    private bool loading = true;
    private static bool returedFromGame = false;

    private void Start()
    {
        #if !UNITY_ANDROID && !UNITY_IOS
        quitButton.SetActive(true);
        #endif
        
        loading = false;
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
            int levelIndex = index;
            newLevelButton.GetComponent<Button>().onClick.AddListener(() =>
                StartCoroutine(LoadSceneWithDelay($"Level_{levelIndex}"))
            );
        }
    }

    private void OnEnable() => StartCoroutine(OpenMenuWithDelay());

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !loading)
        {
            if (resetPopup.activeInHierarchy)
                AbortReset();
            else if (!mainMenu.activeInHierarchy)
                Back();
            else
                ConfirmQuit();
        }
    }

    private IEnumerator OpenMenuWithDelay()
    {
        yield return new WaitForSecondsRealtime(loadDelay);

        if (returedFromGame) GameStart();
        else Back();
        loading = false;
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
        StartCoroutine(LoadSceneWithDelay(SceneManager.GetActiveScene().name, false, false));
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
    
    private IEnumerator LoadSceneWithDelay(string sceneName, bool buttonSound = true, bool loadLevelScene = true)
    {
        loading = true;
        returedFromGame = loadLevelScene;

        if (buttonSound) AudioManager.PlaySound?.Invoke(AudioManager.SFXName.BUTTON);

        levelMenu.SetActive(false);
        resetPopup.SetActive(false);
        menuBase.SetActive(false);
        loadingBanner.SetActive(true);

        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(sceneName);
    }
}
