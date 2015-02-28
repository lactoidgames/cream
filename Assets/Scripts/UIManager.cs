using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	public GameObject mainPnl;
	public GameObject newgamePnl;
	public GameObject charselectPnl;
	public GameObject gamePnl;
	public GameObject[] pnls;

	public MainManager mainManager;

	public void SetActiveMenu(GameObject pnl)
	{
		foreach(GameObject p in pnls)
		{
			p.SetActive(false);
		}
		pnl.SetActive (true);
	}
	
	void Start()
	{
		pnls = new GameObject[] {mainPnl, newgamePnl, charselectPnl, gamePnl};
		SetActiveMenu (mainPnl);

	}

	public void StartTimeTrial()
	{
		mainManager.SpawnPlayer ("andrew");
		Application.LoadLevel ("Main");
	}

	public Text scoreText;
	public Text timeText;
	private int score;
	public int time;

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = score + " Coins";
	}

}
