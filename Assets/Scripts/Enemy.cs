using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool multipleHits = true;
    [SerializeField] private int damageAmount;
    public int health = 1;

    public float startSpeed = 10f;

    [SerializeField] private AudioClip enemyJuicyExplosion;
    [SerializeField] private AudioClip enemyExplosion;


    private LerpColor lerpColor;

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject hitEffect;

    [HideInInspector]
    public float speed;

    [SerializeField] private float lifeTime = 30f;
    [SerializeField] private float lifeTimeFactor = 1f;

    void Start()
    {
        speed = startSpeed;
        lerpColor = GetComponent<LerpColor>();
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall") 
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Shockwave")
        {
            if (GameManager.makeItJuicy) AudioSource.PlayClipAtPoint(enemyJuicyExplosion, this.transform.position);
            else if (GameManager.makeItMinimal) AudioSource.PlayClipAtPoint(enemyExplosion, this.transform.position);

            if(other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
            }

            CheckState();
        }
    }

    void CheckState()
    {
        if (health <= 0 || multipleHits)
        {
            if (GameManager.makeItJuicy)
            {
                GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(effect, 5f);
            }
            Destroy(this.gameObject);
        }
        else
        {
            if (GameManager.makeItJuicy)
            {
                if (!lerpColor.isRunning) StartCoroutine(lerpColor.StartLerping());
                GameObject effect = (GameObject)Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 5f);
            } else if (GameManager.makeItMinimal)
            {
                StartCoroutine(lerpColor.StartLerping());
            }
            health--;
        }
        lifeTime -= Time.deltaTime * lifeTimeFactor;
    }
}
