using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private bool hasBeenActived = false;

    private Vector3 originalPos;
    private Vector3 newPos;
    [SerializeField] private Vector3 offset;
    private float movementStep = 0.5f;

    private float buttonTimer = 0f;
    private float buttonTimerThreshold = 1.1f;

    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalPos = transform.position;
        newPos = originalPos + offset;
    }

    private void Update()
    {
        buttonTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && buttonTimer > buttonTimerThreshold)
        {
            ResetTimer();
            AudioManager.instance.PlaySoundAt(clip, transform.position, 1f);
            transform.position = Vector3.MoveTowards(transform.position, newPos, movementStep);
            hasBeenActived = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, movementStep);
        }
    }

    void ResetTimer()
    {
        buttonTimer = 0f;
    }
}
