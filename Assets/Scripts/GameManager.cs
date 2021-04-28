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
		hud.SetPointCounter(PlayerStats.currScore);
		hud.SetHealthAmount(PlayerStats.currHealth);
		if (GameIsOver)
			return;

		if (Input.GetKey(KeyCode.J) && !makeItJuicy)
        {
			makeItMinimal = false;
			makeItJuicy = !makeItJuicy;
			Debug.Log("Juicy: " + makeItJuicy);
		}
		if (Input.GetKey(KeyCode.M) && !makeItMinimal)		{
			makeItJuicy = false;
			makeItMinimal = !makeItMinimal;
			Debug.Log("Minimal: " + makeItMinimal);
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
