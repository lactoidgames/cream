using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public GameObject newGameBtn;
	public GameObject settingsBtn;
	public GameObject randomBtn;
	public GameObject friendsBtn;
	public GameObject timeBtn;
	public GameObject backBtn;
	
	public void NewGame()
	{
		newGameBtn.SetActive (false);
		settingsBtn.SetActive (false);
		randomBtn.SetActive (true);
		friendsBtn.SetActive (true);
		timeBtn.SetActive (true);
		backBtn.SetActive (true);
	}

	public void MainMenu()
	{
		newGameBtn.SetActive (true);
		settingsBtn.SetActive (true);
		randomBtn.SetActive (false);
		friendsBtn.SetActive (false);
		timeBtn.SetActive (false);
		backBtn.SetActive (false);
	}

	public void StartTimeTrial()
	{
		Application.LoadLevel ("Main");
	}

}
