using UnityEngine;
using System.Collections;

public class ClickSetPosition : MonoBehaviour {
	
	private GameObject player;
	private PlayerManager playerManager;

	void Start()
	{
		player = GameObject.Find ("player");
		playerManager = player.GetComponent("PlayerManager") as PlayerManager;
	}

	void OnMouseDown()
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
