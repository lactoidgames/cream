using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

	public string avatar;

	// Use this for initialization
	void Start () {
		byte[] image = System.IO.File.ReadAllBytes ("Assets/Sprites/" + avatar + ".png");
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		sprite.sprite.texture.LoadImage (image);

	}

}
