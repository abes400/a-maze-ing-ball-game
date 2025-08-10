using UnityEngine;

public class TitleMenus : MonoBehaviour
{
    [SerializeField] GameObject Logo;
    [SerializeField] GameObject Byline;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject LevelMenu;
    [SerializeField] GameObject InstructionsMenu;
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject AboutMenu;
    [SerializeField] GameObject QuitPopup;
    public void GameStart()
    {
        MainMenuSetActive(false);
        LevelMenu.SetActive(true);
    }

    public void Instructions()
    {
        MainMenuSetActive(false);
        InstructionsMenu.SetActive(true);
    }

    public void Options()
    {
        MainMenuSetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void About()
    {
        MainMenuSetActive(false);
        AboutMenu.SetActive(true);
    }

    public void Quit()
    {
        MainMenuSetActive(false);
        QuitPopup.SetActive(true);
    }

    public void Back()
    {
        LevelMenu.SetActive(false);
        InstructionsMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        AboutMenu.SetActive(false);
        //QuitPopup.SetActive(false);

        MainMenuSetActive(true);
    }


    private void MainMenuSetActive(bool active)
    {
        Logo.SetActive(active);
        Byline.SetActive(active);
        MainMenu.SetActive(active);
    }
}
