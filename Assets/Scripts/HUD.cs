using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HUD : MonoBehaviour
{
    public static HUD instance = null;

    [SerializeField] TextMeshProUGUI pointCounter = null;
    [SerializeField] Image healthAmount = null;

    public float timer, refresh, avgFramerate;
    [SerializeField] TextMeshProUGUI fpsCounter = null;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        Reset();
    }

    private void Update()
    {
        fpsCounter.text = ((int) (1.0f / Time.unscaledDeltaTime)).ToString() + " FPS";
    }

    public void SetHealthAmount(float value)
    {
        healthAmount.fillAmount = value;
    }

    public void Reset()
    { 
        healthAmount.fillAmount = 1.0f;
        pointCounter.text = "0";
    }

    public void SetPointCounter(int value)
    {
        pointCounter.text = value.ToString();
    }
}
