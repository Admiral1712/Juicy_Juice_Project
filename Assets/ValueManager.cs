using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    public float playerHealth { get; private set; } = 0.9f;
    public int stoneCount { get; private set; } = 0;

    public bool torchOn { get; private set; } = false;

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
        stoneCount = 0;
    }

    public void SetPlayerHealth(float value)
    {
        playerHealth = value;
        hud.SetHealthAmount(playerHealth);
    }

    public void SetStoneCount(int value)
    {
        stoneCount = value;
        hud.SetStoneCount(stoneCount);
    }

    public void SetTorchOn(bool value)
    {
        torchOn = value;
        hud.SetTorchOn(value);
    }
}
