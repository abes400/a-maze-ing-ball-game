using UnityEngine;
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
    [SerializeField] GameObject quitPopup;
    [SerializeField] GameObject contentOfLevelView;

    GameObject[] levelButtons;

    public void Start()
    {
        int unlockedUpto = PlayerPrefs.GetInt("Unlocked_Upto");
        if (unlockedUpto == 0)
        {
            PlayerPrefs.SetInt("Unlocked_Upto", 1);
            unlockedUpto = 1;
        }
        
        levelButtons = new GameObject[levelCount];
        for (int index = 1; index <= levelCount; index++)
        {
            GameObject newLevelButton = Instantiate(levelButtonPrefab, contentOfLevelView.transform);
            newLevelButton.GetComponent<LevelButton>().InitButton(index, unlockedUpto);
            levelButtons[index - 1] = newLevelButton;
        }
    }
    public void GameStart()
    {
        mainMenuSetActive(false);
        levelMenu.SetActive(true);
    }

    public void Instructions()
    {
        mainMenuSetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void Options()
    {
        mainMenuSetActive(false);
        optionsMenu.SetActive(true);
    }

    public void About()
    {
        mainMenuSetActive(false);
        aboutMenu.SetActive(true);
    }

    public void Quit()
    {
        mainMenuSetActive(false);
        quitPopup.SetActive(true);
    }

    public void Back()
    {
        levelMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        aboutMenu.SetActive(false);
        quitPopup.SetActive(false);

        mainMenuSetActive(true);
    }

    public void ConfirmQuit()
    {
        Debug.Log("Program ended.");
        Application.Quit(0);
    }


    private void mainMenuSetActive(bool active)
    {
        logo.SetActive(active);
        byLine.SetActive(active);
        mainMenu.SetActive(active);
    }
}
