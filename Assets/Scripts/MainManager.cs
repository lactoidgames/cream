using UnityEngine;
using System.Collections;

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

}
