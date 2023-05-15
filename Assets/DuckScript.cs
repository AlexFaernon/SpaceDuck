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
        rb.velocity = direction * speed;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.GameOver();
        }
    }

    private void OnDestroy()
    {
        DuckSpawner.KillDucks.RemoveListener(Die);
    }
}
