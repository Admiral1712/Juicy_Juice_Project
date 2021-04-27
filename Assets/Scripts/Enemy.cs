using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool multipleHits = true;
    [SerializeField] private int damageAmount;
    [SerializeField] private int health = 1;

    public float startSpeed = 10f;

    [SerializeField] private AudioClip enemyExplosion;

    [SerializeField] private HitEffect hasChildrenEffect;

    [HideInInspector]
    public float speed;

    [SerializeField] private float lifeTime = 30f;
    [SerializeField] private float lifeTimeFactor = 1f;

    void Start()
    {
        speed = startSpeed;
        hasChildrenEffect = this.gameObject.GetComponentInChildren<HitEffect>();
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall") Destroy(this.gameObject);
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(enemyExplosion, this.transform.position);
            if (hasChildrenEffect != null) hasChildrenEffect.PlayHit();
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);

            CheckState();
        }
    }

    void CheckState()
    {
        if (health <= 0 || multipleHits) Destroy(this.gameObject);
        else health--;
        lifeTime -= Time.deltaTime * lifeTimeFactor;
    }
}
