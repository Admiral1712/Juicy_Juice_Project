using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points;

    [SerializeField] private GameObject collectEffect;

    [SerializeField] private AudioClip collectSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().IncreaseScore(points);
            GameObject effect = (GameObject)Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            AudioManager.instance.PlaySoundAt(collectSound, transform.position);
            Destroy(this);
        }
    }
}
