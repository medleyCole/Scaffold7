using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{

    public GameObject enemy;
    public Transform[] spawnspots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    void Update(){
        if(timeBtwSpawns <= 0)
        {
            int randPos = UnityEngine.Random.Range(0, spawnspots.Length-1);
            Instantiate(enemy, spawnspots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    private void Instantiate(GameObject enemy, Transform transform, Quaternion identity)
    {
        throw new NotImplementedException();
    }
}
