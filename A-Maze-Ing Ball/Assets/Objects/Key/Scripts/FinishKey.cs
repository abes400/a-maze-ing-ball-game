using UnityEngine;
using System;

public class FinishKey : MonoBehaviour
{
    public static event Action OnUnlock;

    public void Collect()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.KEY);
        OnUnlock?.Invoke();
        gameObject.SetActive(false);
    }
}
