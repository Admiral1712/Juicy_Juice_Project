using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Items_Spawner : MonoBehaviour
{
    public Vector3 size;

    public GameObject RedBottlePrefab;
    public GameObject BlueBottlePrefab;
    public GameObject GreenBottlePrefab;
    public GameObject BoxPrefab;
    public GameObject CoinPrefab;

    private bool isSpawningHealth;
    private bool isSpawningGreen;
    private bool isSpawningBlue;
    private bool isSpawningBox;
    private bool isSpawningCoin;

    private void Awake()
    {
        isSpawningBlue = false;
        isSpawningGreen = false;
        isSpawningBox = false;
        isSpawningCoin = false;
        isSpawningHealth = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawningHealth)
        {
            float timerHealth = Random.Range(45, 60);
            Invoke("SpawnHealth", timerHealth);
            isSpawningHealth = true;
        }

        if (!isSpawningGreen)
        {
            float timerGreen = Random.Range(60, 85);
            Invoke("SpawnGreen", timerGreen);
            isSpawningGreen = true;
        }

        if (!isSpawningBlue)
        {
            float timerBlue = Random.Range(60, 85);
            Invoke("SpawnBlue", timerBlue);
            isSpawningBlue = true;
        }

        if (!isSpawningCoin)
        {
            float timerCoin = Random.Range(25, 40);
            Invoke("SpawnCoin", timerCoin);
            isSpawningCoin = true;
        }

        if (!isSpawningBox)
        {
            float timerBox = Random.Range(90, 150);
            Invoke("SpawnBox", timerBox);
            isSpawningBox = true;
        }
    }

    void SpawnHealth()
    {
        Vector3 pos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(RedBottlePrefab, pos, Quaternion.identity);
        isSpawningHealth = false;
    }
    void SpawnGreen()
    {
        Vector3 pos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(GreenBottlePrefab, pos, Quaternion.identity);
        isSpawningGreen = false;
    }
    void SpawnBlue()
    {
        Vector3 pos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(BlueBottlePrefab, pos, Quaternion.identity);
        isSpawningBlue = false;
    }
    void SpawnBox()
    {
        Vector3 pos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.6f, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(BoxPrefab, pos, Quaternion.identity);
        isSpawningBox = false;
    }
    void SpawnCoin()
    {
        Vector3 pos = transform.localPosition + new Vector3(Random.Range(-size.x / 2, size.x / 2), -0.5f, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(CoinPrefab, pos, Quaternion.identity);
        isSpawningCoin = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition, size);
    }
}
