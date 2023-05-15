using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private TMP_Text _text;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void OnClick()
    {
        if (DuckSpawner.IsSpawning)
        {
            GameManager.GameOver();
            _text.text = "Start";
        }
        else
        {
            GameManager.StartGame();
            _text.text = "Stop";
        }
    }
}
