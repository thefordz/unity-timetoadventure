using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public GameObject boarPrefab;
    public bool stopSpawner = false;
    public float spawnTime;
    public float spawnDelay;
    

    private void Start()
    {
        InvokeRepeating("SpawnObj", spawnTime, spawnDelay);
    }
    

    public void SpawnObj()
    {
        Instantiate(boarPrefab, new Vector3(Random.Range(20   ,70),-4.19f, 0), Quaternion.identity);
        if (stopSpawner)
        {
            CancelInvoke("SpawnObj");
        }
    }
}
