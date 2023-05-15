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
    [SerializeField] private float spawnRadius;
    [SerializeField] private float deadZone;
    [SerializeField] private GameObject duck;
    private static DuckSpawner _duckSpawner;
    public static UnityEvent KillDucks;

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
            }
            else
            {
                KillDucks.Invoke();
                _duckSpawner.StopAllCoroutines();
            }
        }
    }

    private void Awake()
    {
        StartCoroutine(WaitToSpawn());
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
        coord += coord.normalized * deadZone;
        var pos = new Vector3(coord.x, transform.position.y, coord.y);
        Instantiate(duck, pos, Quaternion.identity);
        
        
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnDucks());
    }
}
