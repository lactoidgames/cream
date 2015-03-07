using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	private MainManager mainManager;
	
	void Start()
	{
		//get reference to MainManager script
		GameObject mainControl = GameObject.FindWithTag("MainControl");
		if (mainControl != null)
		{
			mainManager = mainControl.GetComponent<MainManager>();
		}
		if (mainControl == null)
		{
			Debug.Log ("Cannot find ‘MainManager’ script");
		}

		//set UI panel to the game panel
		mainManager.SetActiveMenu (mainManager.gamePnl);
		mainManager.background.SetActive (false);

		mainManager.spawnCoin (50);
		StartCoroutine (mainManager.SpawnCoins ());

		waypoints = new GameObject[] {waypoint1, waypoint2, waypoint3, waypoint4, 
									  waypoint5, waypoint6, waypoint7, waypoint8};
		StartCoroutine(SpawnCars ());
	}

	void Update()
	{
		mainManager.timeText.text = mainManager.time.ToString();
	}

	public GameObject waypoint1;
	public GameObject waypoint2;
	public GameObject waypoint3;
	public GameObject waypoint4;
	public GameObject waypoint5;
	public GameObject waypoint6;
	public GameObject waypoint7;
	public GameObject waypoint8;
	public GameObject[] waypoints;
	public float speed;

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

	void ChangeCarSprite(GameObject car, string name)
	{
		byte[] image = System.IO.File.ReadAllBytes ("Assets/Sprites/" + name + ".png");
		SpriteRenderer sprite = car.GetComponent<SpriteRenderer> ();
		sprite.sprite.texture.LoadImage (image);
	}
		                          


}
