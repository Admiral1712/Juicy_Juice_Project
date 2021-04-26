using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed = 35;
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayfieldBounds"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Health h = other.gameObject.GetComponent<Health>();
            if (h != null)
            {
                h.ReceiveDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}
