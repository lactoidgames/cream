using UnityEngine;
using System.Collections;

public class ClickSetPosition : MonoBehaviour {
	
	public Movement charlie;
	
	void OnMouseDown()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		Physics.Raycast(ray, out hit);
		
		if(hit.collider.gameObject == gameObject)
		{
			Vector3 newTarget = hit.point + new Vector3(0, 0, 0);
			charlie.Target = newTarget;
		}
	}
}
