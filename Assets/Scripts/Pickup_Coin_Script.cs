using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin_Script : MonoBehaviour
{
    private PlayerStats stats;
    [SerializeField] int WorthAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Coin");

            Destroy(gameObject);

            stats.IncreaseScore(WorthAmount);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
