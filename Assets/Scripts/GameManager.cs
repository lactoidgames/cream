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

		waypoints = new GameObject[] {waypoint1, waypoint2, waypoint3, waypoint4};
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
	public GameObject[] waypoints;
	public float speed;

	IEnumerator SpawnCars()
	{
		while (true)
		{
			foreach(GameObject w in waypoints)
			{
				GameObject car = Instantiate(Resources.Load("carplaceholder")) as GameObject;
				car.transform.position = w.transform.position;
				car.name = "car";
				if (w.tag == "left")
				{
					Vector3 newScale = car.transform.localScale;
					newScale.x *= -1;
					car.transform.localScale = newScale;
				}
				yield return new WaitForSeconds(1);
			}
			yield return new WaitForSeconds(2);
		}
	}
		                          


}
