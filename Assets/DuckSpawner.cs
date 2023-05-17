using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class DuckSpawner : MonoBehaviour
{
    [SerializeField] private float firstSpawnDelay;
    [SerializeField] private float spawnInterval;
    public float spawnRadius;
    [SerializeField] private float deadZone;
    [SerializeField] private GameObject duck;
    private static DuckSpawner _duckSpawner;
    public static UnityEvent KillDucks = new();

    private static bool _isSpawning;
    public static bool IsSpawning
    {
        get => _isSpawning;
        set
        {
            _isSpawning = value;
            if (value)
            {
                _duckSpawner.StartCoroutine(_duckSpawner.WaitToSpawn());
                ScoreCounter.killCount = 0;
            }
            else
            {
                KillDucks.Invoke();
                Debug.Log("Stop");
                _duckSpawner.StopAllCoroutines();
            }
        }
    }

    private void Awake()
    {
        _duckSpawner = this;
    }

    private IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(firstSpawnDelay);

        StartCoroutine(SpawnDucks());
    }
    
    private IEnumerator SpawnDucks()
    {
        var coord = Random.insideUnitCircle * spawnRadius;
        var pos = new Vector3(coord.x + transform.position.x, transform.position.y, coord.y + transform.position.z);
        Instantiate(duck, pos, Quaternion.identity);
        
        var spawnDelay = Math.Clamp(spawnInterval - ScoreCounter.killCount / 3, 1, 10);
        Debug.Log(spawnDelay);
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnDucks());
    }
}
