using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Green_Bottle_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Drinking");

            GameObject.Find("Player").GetComponent<PlayerController>().StatIncreaseDurationStart();

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
