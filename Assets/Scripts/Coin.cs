using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points;

    [SerializeField] private AudioClip collectSound;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().IncreaseScore(points);

            if (GameManager.makeItJuicy || GameManager.makeItMinimal)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            Destroy(this.gameObject);
        }
    }
}
