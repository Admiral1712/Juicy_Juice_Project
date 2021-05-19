using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSpawner : MonoBehaviour
{
    public Vector3 size;

    public GameObject EnemySpawnerPrefab;

    private bool isSpawning;


    private void Awake()
    {
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            float timerHealth = Random.Range(30, 45);
            Invoke("SpawnSpawner", timerHealth);
            isSpawning = true;
        }

    }

    void SpawnSpawner()
    {
        Vector3 pos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(EnemySpawnerPrefab, pos, Quaternion.identity);
        isSpawning = false;
    }
   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition, size);
    }
}
