using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave_Script : MonoBehaviour
{
    [SerializeField] private Enemy enemyScript;
    private bool touchingSomething = false;
    void Update()
    {
        Expand();

    }
    void Expand()
    {
        float expansionFactor = 16.0f;
        transform.localScale += new Vector3(expansionFactor, 0, expansionFactor) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyScript.health--;

            //Destroy(other.gameObject);
        }
    }


}
