using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
            collision.gameObject.SetActive(false);
    }
}
