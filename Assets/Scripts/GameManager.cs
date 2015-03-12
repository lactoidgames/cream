using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private MainManager mainManager;
	
	public BoxCollider2D building1;
	public BoxCollider2D building2;
	public BoxCollider2D building3;
	public BoxCollider2D building4;
	public BoxCollider2D building5;
	public BoxCollider2D building6;
	public BoxCollider2D building7;
	public BoxCollider2D building8;
	private BoxCollider2D[] buildings;

	public GameObject waypoint1;
	public GameObject waypoint2;
	public GameObject waypoint3;
	public GameObject waypoint4;
	public GameObject waypoint5;
	public GameObject waypoint6;
	public GameObject waypoint7;
	public GameObject waypoint8;
	private GameObject[] waypoints;

	public float speed;
	private bool coinSpawnable;
	
	void Start()
	{
		//gets reference to MainManager script
		GameObject mainControl = GameObject.FindWithTag("MainControl");
		if (mainControl != null)
		{
			mainManager = mainControl.GetComponent<MainManager>();
		}
		if (mainControl == null)
		{
			Debug.Log ("Cannot find ‘MainManager’ script");
		}

		//sets UI panel to the game panel
		mainManager.SetActiveMenu (mainManager.gamePnl);
		mainManager.background.SetActive (false);

		waypoints = new GameObject[] {waypoint1, waypoint2, waypoint3, waypoint4, 
									  waypoint5, waypoint6, waypoint7, waypoint8};

		buildings = new BoxCollider2D[] {building1, building2, building3, building4, 
										 building5, building6, building7, building8};

		StartCoroutine (SpawnCoins ());
		StartCoroutine(SpawnCars ());
	}

	void Update()
	{
		mainManager.timeText.text = mainManager.time.ToString();
	}

	IEnumerator SpawnCars()
	{
		while (true)
		{
			foreach(GameObject w in waypoints)
			{
				GameObject car = Instantiate(Resources.Load("car")) as GameObject;
				car.transform.position = w.transform.position;
				car.name = "car";
				if (w.tag == "right")
				{
					ChangeCarSprite(car, "carplaceholder");
				}
				if (w.tag == "left")
				{
					ChangeCarSprite(car, "carplaceholder");
				}
				if (w.tag == "up")
				{
					ChangeCarSprite(car, "carplaceholder");
				}
				if (w.tag == "down")
				{
					ChangeCarSprite(car, "carplaceholder");
				}
				yield return new WaitForSeconds(1);
			}
			yield return new WaitForSeconds(2);
		}
	}

	IEnumerator SpawnCoins()
	{
		while (true) 
		{
			spawnCoin (1);
			yield return new WaitForSeconds (1);
			mainManager.time = mainManager.time - 1;
			
			if (mainManager.time == 0)
			{
				mainManager.GameOver ();
				break;
			}
		}
	}
	
	void spawnCoin (int n)
	{
		coinSpawnable = true;

		for (int i = 0; i < n; i++)
		{
			Vector2 spawnLocation = new Vector2 (Random.Range (-5.4f, 5.4f), Random.Range (-4.2f, 4.2f));

			for (int j = 0; j < buildings.Length; j++)
			{
				if(buildings[j].bounds.Contains(spawnLocation))
				{
					coinSpawnable = false;
				}
			}

			if(coinSpawnable == true)
			{
				GameObject coin = Instantiate(Resources.Load("coin")) as GameObject;
				coin.transform.Translate(spawnLocation);
				coin.name = "coin";
			}
		}
	}

	void ChangeCarSprite(GameObject car, string name)
	{
		byte[] image = System.IO.File.ReadAllBytes ("Assets/Sprites/" + name + ".png");
		SpriteRenderer sprite = car.GetComponent<SpriteRenderer> ();
		sprite.sprite.texture.LoadImage (image);
	}
		                          


}
