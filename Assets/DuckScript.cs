using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody rb;
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        DuckSpawner.KillDucks.AddListener(Die);
    }


    private void Update()
    {
        var direction = (player.position - transform.position).normalized;
        transform.up = direction;
        var ducksAnger = ScoreCounter.killCount / 3;
        var actualSpeed = speed;
        if (ducksAnger > 5)
        {
            actualSpeed += (ducksAnger - 5) * 1;
        }
        rb.velocity = direction * actualSpeed;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreCounter.killCount++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.GameOver();
            Debug.Log("Killed by duck");
        }
    }

    private void OnDestroy()
    {
        DuckSpawner.KillDucks.RemoveListener(Die);
        var list = new List<Rigidbody>();
        foreach (Transform child in transform)
        {
            list.Add(child.gameObject.AddComponent<Rigidbody>());
        }
        transform.DetachChildren();
        foreach (var rb in list)
        {
            rb.AddForce(UnityEngine.Random.onUnitSphere * 10, ForceMode.VelocityChange);
            rb.AddTorque(UnityEngine.Random.onUnitSphere * 5, ForceMode.VelocityChange);
            Destroy(rb.gameObject, 5);
        }
    }
}
