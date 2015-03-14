using UnityEngine;
using System.Collections;

public class CarManager : MonoBehaviour {

	public float speed;

	void Update()
	{
		if (this.tag == "downright0" || this.tag == "downright1")
		{
			this.transform.Translate (new Vector2(0.5f, -0.25f) * speed * Time.deltaTime);
		}
		if (this.tag == "upleft0" || this.tag == "upleft1")
		{
			this.transform.Translate (new Vector2(-0.5f, 0.25f) * speed * Time.deltaTime);
		}
		if (this.tag == "upright0" || this.tag == "upright1")
		{
			this.transform.Translate (new Vector2(0.5f, 0.25f) * speed * Time.deltaTime);
		}
		if (this.tag == "downleft0" || this.tag == "downleft1")
		{
			this.transform.Translate (new Vector2(-0.5f, -0.25f) * speed * Time.deltaTime);
		}
	}

	void OnEnable()
	{
		Invoke ("Destroy", 4.5f);
	}

	void Destroy()
	{
		gameObject.SetActive (false);
	}

	void OnDisable()
	{
		CancelInvoke();
	}
}
