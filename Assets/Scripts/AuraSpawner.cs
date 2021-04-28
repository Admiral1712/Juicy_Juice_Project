using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AuraSpawner : MonoBehaviour
{
    [SerializeField] private GameObject instance;

    [SerializeField] private float waitFor = 2f;

    private bool isRunning = false;

    private NavMeshAgent agent;

    private int enemyCount;
    [SerializeField] private int spawnThreshold = 20;
    [SerializeField] private float spawnRateFactor = 1f;

    public float wanderRadius;
    //public float wanderTimer;

    Vector3 newDist;

    void Update() {
        if (!isRunning) StartCoroutine(StartSpawning());

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    IEnumerator StartSpawning()
    {
        isRunning = true;
        while(isRunning)
        {
            CheckState();
            SpawnEnemy();
            yield return new WaitForSeconds(waitFor * spawnRateFactor);
        }
        isRunning = false;
    }

    private void SpawnEnemy()
    {
        if (enemyCount < spawnThreshold)
        {
            newDist = RandomNavSphere(transform.position, wanderRadius, -1);
            if (newDist.magnitude != Mathf.Infinity)
            {
                GameObject enemyInstance = (GameObject)Instantiate(instance, newDist, Quaternion.identity);
            }
        }
    }

    private void CheckState()
    {
        //am i alive?
    }


    //return random pos on navmesh
    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

}
