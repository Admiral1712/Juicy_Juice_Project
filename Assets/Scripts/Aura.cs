using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    [SerializeField] private GameObject auraEffect;
    [SerializeField] private LerpColor color;

    [SerializeField] private float healingDuration = 2f;
    [SerializeField] private int healingAmount = 1;

    [SerializeField] private float healingIntervall = 0.2f;
    [SerializeField] private float timer = 0;

    [SerializeField] private bool isRunning = false;
    [SerializeField] private AudioClip auraSound;

    private void Start()
    {
        color = GetComponent<LerpColor>();
        color.setGlowDuration(healingDuration);
        timer = healingIntervall;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isRunning)
            {
                StartCoroutine(StartHealing());
                StartCoroutine(color.StartLerping());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isRunning && other.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer > healingIntervall)
            {
                other.GetComponent<PlayerController>().ReceiveHealing(healingAmount);
                timer = 0;
            }
        } 
    }

    private IEnumerator StartHealing()
    {
        isRunning = true;
        PlayEffect();
        yield return new WaitForSeconds(healingDuration);
        isRunning = false;
    }

    void PlayEffect()
    {
        if (GameManager.makeItJuicy)
        {
            AudioSource.PlayClipAtPoint(auraSound, this.transform.position);
            GameObject effect = (GameObject)Instantiate(auraEffect, transform.position, Quaternion.identity);
            Destroy(effect, healingDuration);
        }
        else if (GameManager.makeItMinimal)
        {
            AudioSource.PlayClipAtPoint(auraSound, this.transform.position);
        }
    }
}
