using UnityEngine;

public class Ball : MonoBehaviour
{

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
