using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner spawner;
    private List<Transform> sides = new List<Transform>();
    public GameObject enemyPrefab;
    public int index = 0;


    void Awake()
    {
        if (spawner == null)
        {
            spawner = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
		foreach(Transform child in transform)
        {
            sides.Add(child);
        }
	}
	
    public void Spawn(int index)
    {
        Transform side = sides[index];
        Transform SpawnPoints = side.gameObject.transform.GetChild(0);
        List<Transform> spawnPointsList = new List<Transform>();

        foreach(Transform child in SpawnPoints)
        {
            spawnPointsList.Add(child);
        }

        System.Random rng = new System.Random();

        for (int i = 0; i < 6; i++)
        {
            Transform position = spawnPointsList[rng.Next(0, 18)];
            Instantiate(enemyPrefab, position);
        }

    }
}
