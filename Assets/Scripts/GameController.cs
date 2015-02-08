using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject coin;
	public Text scoreText;
	public Text timeText;
	private int score;
	public int time;
		
	void Start ()
	{
		score = 0;
		spawnCoin (200);
		StartCoroutine (StartGame ());
		UpdateScore ();
	}

	IEnumerator StartGame()
	{
		while (time>0) {
			spawnCoin (1);
			timeText.text = time.ToString ();
			yield return new WaitForSeconds (1);
			time -= 1;
		}
	}

	void spawnCoin (int n)
	{
		if (n>0)
		{
			for (int i = 0; i < n; i++)
			{
				Vector3 coinPosition = new Vector3 (Random.Range (-10f, 10f), Random.Range (-3f, 3f), 0f);
				Instantiate (coin, coinPosition, Quaternion.identity);
			}
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
}
