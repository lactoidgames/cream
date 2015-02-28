using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {
	
	public void spawnCoin (int n)
	{
		if (n>0)
		{
			for (int i = 0; i < n; i++)
			{
				GameObject coin = Instantiate(Resources.Load("coin")) as GameObject;
				coin.transform.Translate(Random.Range (-10f, 10f), Random.Range (-3f, 3f), 0f);
				coin.name = "coin";
			}
		}
	}

	public IEnumerator SpawnCoins()
	{
		while (true) {
			spawnCoin (1);
			yield return new WaitForSeconds (1);
		}
	}

	public void SpawnPlayer(string avatar)
	{
		GameObject player = Instantiate(Resources.Load("player")) as GameObject;
		player.name = "player";
		byte[] image = System.IO.File.ReadAllBytes ("Assets/Sprites/" + avatar + ".png");
		SpriteRenderer sprite = player.GetComponent<SpriteRenderer> ();
		sprite.sprite.texture.LoadImage (image);
	}

	public GameObject mainPnl;
	public GameObject newgamePnl;
	public GameObject charselectPnl;
	public GameObject gamePnl;
	public GameObject background;
	public GameObject[] pnls;
	
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
		SpawnPlayer ("andrew");
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
