using UnityEngine;

public class Finish : MonoBehaviour
{
    [Header("-----    Child GameObjects (DONT'T TOUCH)    -----")]
    [SerializeField] private GameObject enabledLight;
    private bool activated = false;

    void OnEnable() => FinishKey.OnUnlock += OnUnlock;
    void OnDisable() => FinishKey.OnUnlock -= OnUnlock;

    void OnUnlock()
    {
        activated = true;
        enabledLight.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated && collision.CompareTag("Ball"))
            GameManager.FinishLevel();
    }
}
