using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private bool triggered = false;

    private Vector3 originalPos;
    private Vector3 newPos;
    [SerializeField] private Vector3 offset;
    private float movementStep = 1f;

    private float buttonTimer = 0f;
    private float buttonTimerThreshold = 0.9f;

    [SerializeField] private AudioClip clip;

    [SerializeField] private Gate gate;

    private void Awake()
    {
        originalPos = transform.position;
        newPos = originalPos + offset;
        buttonTimer = buttonTimerThreshold;

        gate = GameObject.FindGameObjectWithTag("Gate").GetComponent<Gate>();
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
            AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
            transform.position = Vector3.MoveTowards(transform.position, newPos, movementStep);
            triggered = true;
            StartCoroutine(gate.moveGate());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, movementStep);
            triggered = false;
        }
    }

    void ResetTimer()
    {
        buttonTimer = 0f;
    }
}
