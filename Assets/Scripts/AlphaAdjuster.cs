using UnityEngine;
using System.Collections;

public class AlphaAdjuster : MonoBehaviour {

	private SpriteRenderer spriteRenderer; 
	
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	
	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag == "player")
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,0.5f);
		}
	}
		   
		   
	void OnTriggerExit2D(Collider2D c)
	{			
		if(c.gameObject.tag == "player")
		{
			spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,1f);
		}
	}
}
