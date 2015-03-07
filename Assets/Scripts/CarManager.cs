using UnityEngine;
using System.Collections;

public class CarManager : MonoBehaviour {

	public float speed;
	private string direction;

	void Start()
	{
		if (this.transform.position.y == 1.5f || this.transform.position.y == -1.85f)
		{
			direction = "right";
		}
		if (this.transform.position.y == 2.1f || this.transform.position.y == -1.2f)
		{
			direction = "left";
		}
		if (this.transform.position.x == -3.3f || this.transform.position.x == 2.5f)
		{
			direction = "down";
		}
		if (this.transform.position.x == -2.5f || this.transform.position.x == 3.3f)
		{
			direction = "up";
		}
	}


	void Update()
	{
		if (direction == "right")
		{
			Vector3 right = new Vector3(0.5f, 0f);
			this.transform.Translate (right * speed * Time.deltaTime);
		}
		if (direction == "left")
		{
			Vector3 left = new Vector3(-0.5f, 0f);
			this.transform.Translate (left * speed * Time.deltaTime);
		}
		if (direction == "down")
		{
			Vector3 down = new Vector3(0f, -0.5f);
			this.transform.Translate (down * speed * Time.deltaTime);
		}
		if (direction == "up")
		{
			Vector3 up = new Vector3(0f, 0.5f);
			this.transform.Translate (up * speed * Time.deltaTime);
		}

		if (this.transform.position.x > 6f || this.transform.position.x < -6f ||
		    this.transform.position.y > 5f || this.transform.position.y < -5f)
		{
			Destroy(this.gameObject);
		}
	}
}
