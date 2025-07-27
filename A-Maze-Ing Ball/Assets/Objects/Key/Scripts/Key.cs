using UnityEngine;
using System;

public class Key : MonoBehaviour
{
    public static event Action<short> OnUnlock;
    [SerializeField] short channel;

    public void Collect()
    {
        AudioManager.PlaySound?.Invoke(AudioManager.KEY);
        OnUnlock?.Invoke(channel);
        gameObject.SetActive(false);
    }
}
