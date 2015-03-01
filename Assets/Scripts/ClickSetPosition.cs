using UnityEngine;
using System.Collections;

public class ClickSetPosition : MonoBehaviour {
	
	private GameObject player;
	private PlayerManager playerManager;
	private GameObject mainControl;
	public MainManager mainManager;

	void Start()
	{
		player = GameObject.Find ("player");
		playerManager = player.GetComponent<PlayerManager>();
		mainControl = GameObject.Find ("control_main");
		mainManager = mainControl.GetComponent<MainManager>();
	}

	void OnMouseDown()
	{
		if(mainManager.gameOver == false)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
		
			Physics.Raycast(ray, out hit);
		
			if(hit.collider.gameObject == gameObject)
			{
				Vector3 newTarget = hit.point + new Vector3(0, 0, 0);
				playerManager.Target = newTarget;
			}
		}
	}
}
