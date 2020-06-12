using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Transform[] spawnerPoints;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private float spawnRate; //delay between enemy spawn
    [SerializeField]
    private float spawnCount; //amount of enemy spawned in one time
    void Start()
    {
        
        for (int i = 0;i < spawnerPoints.Length;++i)
        {
            spawnerPoints[i] = transform.GetChild(i);
        }
        StartCoroutine("Spawn");
    }
    

    
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnRate);
        for (int i = 0;i < spawnCount;++i)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)],
                spawnerPoints[Random.Range(0, spawnerPoints.Length)].position,
                Quaternion.identity);
        }
        StartCoroutine("Spawn");
    }
}
