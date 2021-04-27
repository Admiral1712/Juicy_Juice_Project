using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

	[SerializeField] private HUD hud;

	// TODO: no effect currently
	public static bool makeItJuicy = true;


    void Start()
    {
		hud = GetComponent<HUD>();
        GameIsOver = false;
    }
	void Update()
	{
		hud.SetPointCounter(PlayerStats.currScore);
		hud.SetHealthAmount(PlayerStats.currHealth);
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
		GameIsOver = true;
		//Debug.Log("EndGame");
	}

	public void WinLevel()
	{
		//Debug.Log("WinLevel");
	}
}
