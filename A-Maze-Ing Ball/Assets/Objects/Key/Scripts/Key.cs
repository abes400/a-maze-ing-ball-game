using UnityEngine;
using System;

public class Key : MonoBehaviour
{
    public static event Action<short> OnUnlock;
    [SerializeField] short channel;

    public void Collect()
    {
        OnUnlock?.Invoke(channel);
        gameObject.SetActive(false);
    }
}
