using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameObject mainControl;
	public MainManager mainManager;
	
	void Start()
	{
		//get reference to MainManager script
		mainControl = GameObject.Find ("control_main");
		mainManager = mainControl.GetComponent<MainManager>();

		//set UI panel to the game panel
		mainManager.SetActiveMenu (mainManager.gamePnl);
		mainManager.background.SetActive (false);

		mainManager.spawnCoin (50);
		StartCoroutine (mainManager.SpawnCoins ());
	}

	void Update()
	{
		mainManager.timeText.text = mainManager.time.ToString();
	}


}
