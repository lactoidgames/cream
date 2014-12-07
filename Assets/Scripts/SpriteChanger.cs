using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {



	// Use this for initialization
	void Start () {
		byte[] image = System.IO.File.ReadAllBytes ("Assets/Sprites/charlie.png");
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite.texture.LoadImage (image);

	}

}
