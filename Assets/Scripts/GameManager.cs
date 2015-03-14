using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	private MainManager mainManager;
	
	public PolygonCollider2D building1;
	public PolygonCollider2D building2;
	public PolygonCollider2D building3;
	public PolygonCollider2D building4;
	public PolygonCollider2D building5;
	public PolygonCollider2D building6;
	private PolygonCollider2D[] buildings;

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

	public int pooledAmountOfCars = 5;
	List<GameObject> cars;

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

		buildings = new PolygonCollider2D[] {building1, building2, building3, building4, 
										 building5, building6};

		cars = new List<GameObject> ();
		for (int i = 0; i < pooledAmountOfCars; i++)
		{
			GameObject obj = Instantiate(Resources.Load("car")) as GameObject;
			obj.SetActive(false);
			cars.Add(obj);
		}

		StartCoroutine (SpawnCoins ());
		StartCoroutine(SpawnCars ());
	}

	void Update()
	{
		mainManager.timeText.text = mainManager.time.ToString();
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

	IEnumerator SpawnCars()
	{
		while (true)
		{
			foreach(GameObject w in waypoints)
			{                                             
				if (w.tag == "downright0") SpawnCar("carplaceholder_0", w, "downright0");
				if (w.tag == "downright1") SpawnCar("carplaceholder_0", w, "downright1");
				if (w.tag == "downleft0")  SpawnCar("carplaceholder_3", w, "downleft0");
				if (w.tag == "downleft1")  SpawnCar("carplaceholder_3", w, "downleft1");
				if (w.tag == "upright0")   SpawnCar("carplaceholder_2", w, "upright0");
				if (w.tag == "upright1")   SpawnCar("carplaceholder_2", w, "upright1");
				if (w.tag == "upleft0")    SpawnCar("carplaceholder_1", w, "upleft0");
				if (w.tag == "upleft1")    SpawnCar("carplaceholder_1", w, "upleft1");

				yield return new WaitForSeconds(1);
			}
			yield return new WaitForSeconds(2);
		}
	}
	
	
	void SpawnCar(string name, GameObject spawnPosition, string tag)
	{
		for (int i = 0; i < cars.Count; i++)
		{
			if (!cars[i].activeInHierarchy)
			{
				cars[i].SetActive(true);
				cars[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load (name, typeof(Sprite)) as Sprite;
				cars[i].transform.position = spawnPosition.transform.position;
				cars[i].name = "car";
				cars[i].tag = tag;
				break;
			}
		}
	}
}
