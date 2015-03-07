using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainManager : MonoBehaviour {

	public GameObject mainPnl;
	public GameObject newgamePnl;
	public GameObject charselectPnl;
	public GameObject gamePnl;
	public GameObject background;
	public GameObject gameoverPnl;
	public GameObject[] pnls;

	public Text scoreText;
	public Text timeText;
	public Text gameoverText;
	private int score;
	public int time;

	public bool gameOver;
	public EventSystem eventSystem;

	void Start()
	{
		pnls = new GameObject[] {mainPnl, newgamePnl, charselectPnl, gamePnl, gameoverPnl};
		SetActiveMenu (mainPnl);
		gameOver = false;
	}

	public void SetActiveMenu(GameObject pnl)
	{
		foreach(GameObject p in pnls)
		{
			p.SetActive(false);
		}
		pnl.SetActive (true);
	}

	public IEnumerator SpawnCoins()
	{
		while (true) 
		{
			spawnCoin (1);
			yield return new WaitForSeconds (1);
			time = time - 1;
			
			if (time == 0)
			{
				GameOver ();
				break;
			}
		}
	}
	
	public void spawnCoin (int n)
	{
		if (n>0)
		{
			for (int i = 0; i < n; i++)
			{
				GameObject coin = Instantiate(Resources.Load("coin")) as GameObject;
				coin.transform.Translate(Random.Range (-5.4f, 5.4f), Random.Range (-4.2f, 4.2f), 0f);
				coin.name = "coin";
			}
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

	public void StartTimeTrial()
	{
		SpawnPlayer (eventSystem.currentSelectedGameObject.name);
		Application.LoadLevel ("Main");
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
		score = 0;
		time = 10;
		gameOver = false;
	}

	public void MainMenu()
	{
		DestroyAllGameObjects ();
		Application.LoadLevel ("MainMenu");
	}

	public void DestroyAllGameObjects()
	{
		GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
		
		foreach (GameObject g in GameObjects)
		{
			Destroy(g);
		}
	}
		
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = score + " Coins";
	}

	public void GameOver()
	{
		gameOver = true;
		SetActiveMenu (gameoverPnl);
		gameoverText.text = score.ToString();
	}

}
