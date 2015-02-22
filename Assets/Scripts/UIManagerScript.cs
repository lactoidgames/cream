using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public GameObject mainPnl;
	public GameObject newgamePnl;
	public GameObject charselectPnl;
	public GameObject[] pnls;

	void SetActiveMenu(GameObject pnl)
	{
		foreach(GameObject p in pnls)
		{
			p.SetActive(false);
		}
		pnl.SetActive (true);
	}


	void Start()
	{
		pnls = new GameObject[] {mainPnl, newgamePnl, charselectPnl};
		SetActiveMenu (mainPnl);
	}
	
	public void NewGame()
	{
		SetActiveMenu (newgamePnl);
	}

	public void MainMenu()
	{
		SetActiveMenu (mainPnl);
	}

	public void CharSelect()
	{
		SetActiveMenu (charselectPnl);
	}

	public void StartTimeTrial()
	{
		Application.LoadLevel ("Main");
	}

}
