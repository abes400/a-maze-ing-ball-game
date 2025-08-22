using UnityEngine;

public class MobileAdditions : MonoBehaviour
{
    [Header("-----    Child GameObjects (DONT'T TOUCH)    -----")]
    [SerializeField] GameObject pauseButton;

    public void Pause() => GameManager.PauseLevel();
    private void OnEnable()
    {
        GameManager.TogglePause += OnTogglePause;
        GameManager.Finish += OnFinish;
    }
    private void OnDisable()
    {
        GameManager.TogglePause -= OnTogglePause;
        GameManager.Finish -= OnFinish;
    }
    private void OnTogglePause() => pauseButton.SetActive(GameManager.isPlaying);
    private void OnFinish(bool dummy) => pauseButton.SetActive(false);

}
