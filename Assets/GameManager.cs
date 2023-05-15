using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static void StartGame()
    {
        DuckSpawner.IsSpawning = true;
    }

    public static void GameOver()
    {
        DuckSpawner.IsSpawning = false;
    }
}
