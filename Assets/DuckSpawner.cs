using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DuckSpawner : MonoBehaviour
{
    [SerializeField] private float firstSpawnDelay;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject duck;

    private void Awake()
    {
        StartCoroutine(WaitToSpawn());
    }

    private IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(firstSpawnDelay);

        StartCoroutine(SpawnDucks());
    }
    
    private IEnumerator SpawnDucks()
    {
        var coord = Random.insideUnitCircle * 10;
        var pos = new Vector3(coord.x, transform.position.y, coord.y);
        Instantiate(duck, pos, Quaternion.identity);
        
        
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnDucks());
    }
}
