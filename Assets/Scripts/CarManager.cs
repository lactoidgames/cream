using UnityEngine;
using System.Collections;

public class CarManager : MonoBehaviour {

	public float speed;

	void Update()
	{
		if (this.transform.position.y == 1.5f || this.transform.position.y == -1.85f)
		{
			Vector3 right = new Vector3(0.5f, 0f);
			this.transform.Translate (right * speed * Time.deltaTime);
		}

		if (this.transform.position.y == 2.1f || this.transform.position.y == -1.2f)
		{
			Vector3 left = new Vector3(-0.5f, 0f);
			this.transform.Translate (left * speed * Time.deltaTime);
		}

		if (this.transform.position.x > 6f || this.transform.position.x < -6f)
		{
			Destroy(this.gameObject);
		}
	}
}
