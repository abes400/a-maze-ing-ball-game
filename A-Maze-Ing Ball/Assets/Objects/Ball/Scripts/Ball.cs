using UnityEngine;

public class Ball : MonoBehaviour
{

    private void OnEnable()
    {
        GameManager.Finish += OnFinishLevel;
    }

    private void OnDisable()
    {
        GameManager.Finish -= OnFinishLevel;
    }

    private void OnFinishLevel(bool succeeded)
    {
        AudioManager.PlaySound?.Invoke(succeeded ? AudioManager.DAMAGE : AudioManager.DAMAGE /*TODO change with another sound*/);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            GameManager.OnStarCollected(1);
            AudioManager.PlaySound?.Invoke(AudioManager.STAR);
        }
        else if (collision.CompareTag("Key"))
        {
            collision.gameObject.GetComponent<Key>().Collect();
        }
        else if (collision.CompareTag("Fin"))
        {
            GameManager.FinishLevel();

        }
    }
}
