using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject coin;
		
	void Start ()
	{
		spawnCoin (200);
		StartCoroutine (CoinGeneration ());
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
}
