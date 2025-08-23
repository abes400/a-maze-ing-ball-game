using UnityEngine;

public class Ball : MonoBehaviour
{

    private void OnEnable() =>  GameManager.Finish += OnFinishLevel;

    private void OnDisable() => GameManager.Finish -= OnFinishLevel;

    private void OnFinishLevel(bool succeeded)
    {
        AudioManager.PlaySound?.Invoke(succeeded ? AudioManager.SFXName.WIN : AudioManager.SFXName.DAMAGE);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            GameManager.OnStarCollected(1);
            AudioManager.PlaySound?.Invoke(AudioManager.SFXName.STAR);
        }
        else if (collision.CompareTag("EvilStar"))
        {
            collision.gameObject.SetActive(false);
            GameManager.OnStarCollected(-1);
            AudioManager.PlaySound?.Invoke(AudioManager.SFXName.STAR); // TODO: Change audio with another one
        }
        else if (collision.CompareTag("Key"))
        {
            collision.gameObject.GetComponent<Key>().Collect();
        }
        else if (collision.CompareTag("FinishKey"))
        {
            collision.gameObject.GetComponent<FinishKey>().Collect();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Base") && !GameManager.finished)
            GameManager.FailLevel();
    }
}
