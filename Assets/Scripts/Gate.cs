using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private AudioClip gateOpeningSound;
    [SerializeField] private AudioClip gateClosedSound;

    public Vector3 originalPos;
    private float gateMoveStepSize = 15f;

    public Vector3 openGatePosition;
    [SerializeField] private float openingHeight = 3.25f;

    public bool gateIsOpen = false;
    [SerializeField] private float timeToOpenGate;

    [SerializeField] float gateMovingVolume = 0.55f;

    void Start()
    {
        originalPos = transform.position;
        openGatePosition = originalPos + new Vector3(0f, openingHeight, 0f);
    }

    public IEnumerator moveGate()
    {
        yield return new WaitForSeconds(timeToOpenGate);

        if (GameManager.makeItJuicy || GameManager.makeItMinimal) playGateOpeningClip();
        if (gateIsOpen)
        {
            Debug.Log("Closing");
            StartCoroutine(CloseGate());
        }
        else 
        {
            Debug.Log("Opening");
            StartCoroutine(OpenGate());
        }
    }

    public IEnumerator OpenGate()
    {
        while (transform.position != openGatePosition) //smoothly open gate
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, openGatePosition, gateMoveStepSize * Time.deltaTime);
        }
        gateIsOpen = true;
    }

    public IEnumerator CloseGate()
    {
        while (transform.position != originalPos) //smoothly open gate
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, originalPos, gateMoveStepSize * Time.deltaTime);
        }
        gateIsOpen = false;
    }

    public void playGateOpeningClip()
    {
        AudioSource.PlayClipAtPoint(gateOpeningSound, transform.position, gateMovingVolume);
    }

    public void playGateClosedClip()
    {
        AudioSource.PlayClipAtPoint(gateClosedSound, transform.position, gateMovingVolume);
    }

    public void muteAudio()
    {
        gateMovingVolume = 0f;
    }

    public void resetAudio()
    {
        gateMovingVolume = 0.4f;
    }
}
