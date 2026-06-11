using UnityEngine;

public class Finish : MonoBehaviour
{
    [Header("-----    Child GameObjects (DON'T TOUCH)    -----")]
    [SerializeField] private GameObject enabledLight;
    private bool activated = false;

    private void OnEnable() => FinishKey.OnUnlock += OnUnlock;
    private void OnDisable() => FinishKey.OnUnlock -= OnUnlock;

    private void OnUnlock()
    {
        activated = true;
        enabledLight.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated && collision.CompareTag("Ball"))
            GameManager.FinishLevel();
    }
}
