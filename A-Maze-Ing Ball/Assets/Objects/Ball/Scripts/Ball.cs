using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{

    public static event Action<int> OnStarCollected;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            OnStarCollected(1);
        }
            
    }
}
