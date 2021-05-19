using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int health = 4;
    private LerpColor lerpColor;

    [SerializeField] private AudioClip enemyJuicyExplosion;
    [SerializeField] private AudioClip enemyExplosion;

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject hitEffect;


    void Start()
    {
        lerpColor = GetComponent<LerpColor>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ghost")
        {
            if (GameManager.makeItJuicy) AudioSource.PlayClipAtPoint(enemyJuicyExplosion, this.transform.position);

            CheckState();
        }
    }

    void CheckState()
    {
        if (health <= 0)
        {
            if (GameManager.makeItJuicy)
            {
                GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(effect, 5f);
            }
            Destroy(this.gameObject);
            PlayerStats.currScore += 5;
        }
        else
        {
            if (GameManager.makeItJuicy)
            {
                if (!lerpColor.isRunning) StartCoroutine(lerpColor.StartLerping());
                GameObject effect = (GameObject)Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 5f);
            }
            else if (GameManager.makeItMinimal)
            {
                StartCoroutine(lerpColor.StartLerping());
            }
            health--;
        }
    }
}
