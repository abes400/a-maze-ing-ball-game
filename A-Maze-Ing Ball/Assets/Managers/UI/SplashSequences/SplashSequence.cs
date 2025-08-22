using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{
    [SerializeField] int warningDelaySec = 3;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject warningText;

    void Start() => StartCoroutine(ShowWarningSequence());

    #if UNITY_ANDROID
    private void Awake() => Application.targetFrameRate = 60;
    #endif

    private IEnumerator ShowWarningSequence()
    {
        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared);

        yield return new WaitForSeconds(1);

        videoPlayer.Play();
        yield return new WaitUntil(() => videoPlayer.isPlaying);
        while (videoPlayer.isPlaying)
            yield return null;

        warningText.SetActive(true);
        yield return new WaitForSeconds(warningDelaySec);

        SceneManager.LoadScene("MainMenu");
    }
}
