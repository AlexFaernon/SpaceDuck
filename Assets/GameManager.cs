using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private static GameObject canvASS;

    private void Awake()
    {
        canvASS = canvas;
    }

    public static void StartGame()
    {
        DuckSpawner.IsSpawning = true;
    }

    public static void GameOver()
    {
        DuckSpawner.IsSpawning = false;
        canvASS.SetActive(true);
    }
}
