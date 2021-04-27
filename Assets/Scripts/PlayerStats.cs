using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int currHealth;
    public int maxHealth = 20;

    public static int currScore = 0;

    void Start()
    {
        currHealth = maxHealth;
    }

    public float getCurrentHealth()
    {
        return currHealth;
    }

    public void IncreaseScore(int amount)
    {
        currScore += amount;
        Debug.Log("currScore changed! " + currScore);
    }
}
