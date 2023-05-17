using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRecord : MonoBehaviour
{
    public static int highestScore;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (ScoreCounter.killCount > highestScore)
        {
            highestScore = ScoreCounter.killCount;
        }

        text.text = $"Best Score: {highestScore}";
    }
}
