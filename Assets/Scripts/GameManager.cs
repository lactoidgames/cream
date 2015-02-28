using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameObject mainControl;
	
	void Start()
	{
		//get reference to MainManager script
		mainControl = GameObject.Find ("control_main");
		MainManager mainManager = mainControl.GetComponent<MainManager>();

		//set UI panel to the game panel
		mainManager.SetActiveMenu (mainManager.gamePnl);
		mainManager.background.SetActive (false);

		mainManager.spawnCoin (1);
		StartCoroutine (mainManager.SpawnCoins ());
	}


}
