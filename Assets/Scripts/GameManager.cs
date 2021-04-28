using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

	[SerializeField] private HUD hud;

	public static bool makeItJuicy = true;
	public static bool makeItMinimal = false;

	void Start()
    {
		hud = GetComponent<HUD>();
        GameIsOver = false;
    }
	void FixedUpdate()
	{
		// Update UI
		hud.SetPointCounter(PlayerStats.currScore);
		hud.SetHealthAmount(PlayerStats.currHealth);
		hud.SetJuicyText();
		// Stop here if GameIsOver
		if (GameIsOver)
			return;

		// Juicy Control
		if (Input.GetKey(KeyCode.J) && !makeItJuicy)
        {
			makeItMinimal = false;
			makeItJuicy = !makeItJuicy;
		}
		if (Input.GetKey(KeyCode.M) && !makeItMinimal)		{
			makeItJuicy = false;
			makeItMinimal = !makeItMinimal;
		}
		if (Input.GetKey(KeyCode.N))
		{
			makeItJuicy = false;
			makeItMinimal = false;
		}

		if (PlayerStats.currHealth <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
    {
		GameIsOver = true;
		//Debug.Log("EndGame");
	}

	public void WinLevel()
	{
		//Debug.Log("WinLevel");
	}
}
