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
    [SerializeField] TextMeshProUGUI playerHealth = null;
    [SerializeField] TextMeshProUGUI juicyText = null;

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

    public void SetHealthAmount(int value)
    {
        playerHealth.text = "Leben: " + value.ToString();
    }

    public void Reset()
    {
        playerHealth.text = "0";
        pointCounter.text = "0";
    }

    public void SetPointCounter(int value)
    {
        pointCounter.text = "Punkte: " + value.ToString();
    }

    public void SetJuicyText()
    {
        if (GameManager.makeItJuicy) juicyText.text = "Juicy!";
        else if (GameManager.makeItMinimal) juicyText.text = "Minimal";
        else juicyText.text = "None";
    }
}
