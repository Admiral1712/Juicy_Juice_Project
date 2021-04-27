using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public float playerHealth { get; private set; } = 0.9f;
    public int pointCounter { get; private set; } = 0;

    HUD hud = null;

    void Start()
    {
        hud = HUD.instance;
    }

    void Update()
    {
        if (hud == null)
            hud = HUD.instance;
    }

    public void Reset()
    {
        playerHealth = 1.0f;
        pointCounter = 0;
    }

    public void SetPlayerHealth(float value)
    {
        playerHealth = value;
        hud.SetHealthAmount(playerHealth);
    }

    public void SetPointCounter(int value)
    {
        pointCounter = value;
        hud.SetPointCounter(pointCounter);
    }
}
