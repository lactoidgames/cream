﻿using UnityEngine;
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
		GameObject player = GameObject.Find ("player");
		player.transform.position = new Vector2 (0, 0);
		Application.LoadLevel (Application.loadedLevel);
		score = 0;
		time = 60;
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
