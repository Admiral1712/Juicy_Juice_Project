using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

	public static bool makeItJuicy = true;


    void Start()
    {
        GameIsOver = false;
    }
	void Update()
	{
		if (Input.GetKey(KeyCode.J)) makeItJuicy = !makeItJuicy;
		if (GameIsOver)
			return;

		if (PlayerStats.currHealth <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
    {
		Debug.Log("EndGame");
    }

	public void WinLevel()
	{
		Debug.Log("WinLevel");
	}
}
