using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    int collectedStars = 0;

    public static Action<int> UpdateStars;

    void Start() => Ball.OnStarCollected += OnStarCollected;

    void Update()
    {

        //TODO: Handle pause (maybe)
    }

    void OnStarCollected(int incrementSize)
    {
        collectedStars += incrementSize;
        UpdateStars?.Invoke(collectedStars);
    }

}
