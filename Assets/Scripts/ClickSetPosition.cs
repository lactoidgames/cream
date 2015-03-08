using UnityEngine;
using System.Collections;

public class ClickSetPosition : MonoBehaviour {

	private PlayerManager playerManager;
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

		//get reference to PlayerManager script
		GameObject player = GameObject.Find ("player");
		if (player != null)
		{
			playerManager = player.GetComponent<PlayerManager>();
		}
		if (player == null)
		{
			Debug.Log ("Cannot find ‘PlayerManager’ script");
		}
	}
	
	void OnMouseDown()
	{
		if(mainManager.gameOver == false)
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
				Vector2 newTarget = hit.point + new Vector2(0, 0);
				playerManager.Target = newTarget;
			}
		}
	}
}















