using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    private Renderer rend;

    [SerializeField] private Color targetColor;
    private Color startColor;

    private float effectTimer;
    [SerializeField] private float intensity = 1f;
    [SerializeField] float glowDuration = 1f;

    [SerializeField] private float targetIntensity;
    [SerializeField] private float minimumLumination = 0.3f;

    private bool isRunning = false;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        startColor = rend.material.color;
    }

    public IEnumerator StartLerping()
    {
        isRunning = true;
        while (isRunning)
        {
            effectTimer = Mathf.PingPong(Time.time / glowDuration, 1f);
            rend.material.color = Color.Lerp(rend.material.color, targetColor, effectTimer) * intensity;
            yield return new WaitForSeconds(glowDuration);
            StopLerping();
        }
    }

    public IEnumerator StartLerpingWhite()
    {
        isRunning = true;
        while (isRunning)
        {
            effectTimer = Mathf.PingPong(Time.time / glowDuration, 1f);
            rend.material.color = Color.Lerp(rend.material.color, Color.white, effectTimer) * intensity;
            yield return new WaitForSeconds(glowDuration);
            StopLerping();
        }
    }

    public void StopLerping()
    {
        isRunning = false;
        rend.material.color = startColor;
    }

    public void setGlowDuration(float newValue)
    {
        glowDuration = newValue;
    }
}
