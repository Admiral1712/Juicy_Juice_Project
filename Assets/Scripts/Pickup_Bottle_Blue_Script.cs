using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Bottle_Blue_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Drinking");

            GameObject.Find("Player").GetComponent<PlayerController>().GhostStatusStart();

            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
