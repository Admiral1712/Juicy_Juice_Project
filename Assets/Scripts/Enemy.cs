using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    void Start()
    {

    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damageAmount);
            Destroy(this);
        }
    }
}
