using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;

        Destroy(other.gameObject);
        GameManager.StartGame();
        transform.parent.gameObject.SetActive(false);
    }
}
