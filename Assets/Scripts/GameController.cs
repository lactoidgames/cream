using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject coin;
	public Text scoreText;
	private int score;
		
	void Start ()
	{
		score = 0;
		spawnCoin (200);
		StartCoroutine (CoinGeneration ());
		UpdateScore ();
	}
	
	IEnumerator CoinGeneration ()
	{
		
		while (true)
		{
			spawnCoin(1);
			yield return new WaitForSeconds(1);
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
		scoreText.text = "Score: " + score;
	}
}
