using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private MainManager mainManager;
	
	void Start()
	{
		//get reference to MainManager script
		GameObject mainControl = GameObject.FindWithTag("MainControl");
		if (mainControl != null)
		{
			mainManager = mainControl.GetComponent<MainManager>();
		}
		if (mainControl == null)
		{
			Debug.Log ("Cannot find ‘MainManager’ script");
		}

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
