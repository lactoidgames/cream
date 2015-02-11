using UnityEngine;
using System.Collections;

public class ClickSetPosition : MonoBehaviour {
	
	private GameObject myObj;
	private Movement movement;

	void Start()
	{
		myObj = GameObject.Find ("player");
		movement = myObj.GetComponent("Movement") as Movement;
	}

	void OnMouseDown()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		Physics.Raycast(ray, out hit);
		
		if(hit.collider.gameObject == gameObject)
		{
			Vector3 newTarget = hit.point + new Vector3(0, 0, 0);
			movement.Target = newTarget;
		}
	}
}
