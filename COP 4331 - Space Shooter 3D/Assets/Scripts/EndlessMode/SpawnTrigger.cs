using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        int index = EnemySpawner.spawner.index++;
        EnemySpawner.spawner.Spawn(index);
    }
    
}
