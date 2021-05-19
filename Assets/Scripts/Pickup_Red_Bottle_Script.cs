using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Red_Bottle_Script : MonoBehaviour
{
    private PlayerController controller;
    [SerializeField] int HealingAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("HealingPotion");

            controller.ReceiveHealing(HealingAmount);

            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
