using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Box_Script : MonoBehaviour
{
    private PlayerController controller;
    [SerializeField] private Animator animation;
    [SerializeField] private GameObject ShockwavePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animation.SetTrigger("Destroy");
            //Destroy(GetComponent<Transform>().GetChild(1).gameObject);

            FindObjectOfType<AudioManager>().Play("ShockwaveSound");

            Destroy(gameObject, 3f);

            GameObject clone = Instantiate(ShockwavePrefab, this.transform.position, this.transform.rotation);
            Destroy(clone, 2f);
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
