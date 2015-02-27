using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private GameObject mainControl;
	private GameObject uiControl;
	

	void Start()
	{
		//get reference to MainManager script
		mainControl = GameObject.Find ("control_main");
		MainManager mainManager = mainControl.GetComponent<MainManager>();

		//get reference to UIManager script
		uiControl = GameObject.Find ("control_ui");
		UIManager uiManager = uiControl.GetComponent<UIManager>();

		mainManager.spawnCoin (1);
		StartCoroutine (mainManager.SpawnCoins ());
	}


}
