using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public Vector3 Target
	{
		get { return Target; }
		set {
			target = value;
			StopCoroutine("SetTarget");
			StartCoroutine("SetTarget", target);
		}
	}
	
	private Vector3 target;
	public float speed;
	public int scoreValue;
	private GameObject myObj;
	private GameController gameController;
	
	void Start()
	{
		myObj = GameObject.Find ("gamecontrol");
		gameController = myObj.GetComponent("GameController") as GameController;
	}

	IEnumerator SetTarget ()
	{
		Animator anim = GetComponent<Animator>();

		while(Vector3.Distance(transform.position, target) > 0.05f)
		{
			anim.SetBool ("isIdle", false);

			if (target.y < transform.position.y && (Mathf.Abs(transform.position.x - target.x) < Mathf.Abs(transform.position.y - target.y)))
			{
				anim.SetTrigger("TrigDown");
			}
			if (target.y > transform.position.y && (Mathf.Abs(transform.position.x - target.x) < Mathf.Abs(transform.position.y - target.y)))
			{
				anim.SetTrigger("TrigUp");
			}
			if (target.x > transform.position.x && (Mathf.Abs(transform.position.x - target.x) > Mathf.Abs(transform.position.y - target.y)))
			{
				anim.SetTrigger("TrigRight");
			}
			if (target.x < transform.position.x && (Mathf.Abs(transform.position.x - target.x) > Mathf.Abs(transform.position.y - target.y)))
			{
				anim.SetTrigger("TrigLeft");
			}

			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
			yield return null;
		}

		anim.SetBool ("isIdle", true);
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "coin")
		{
			Destroy (coll.gameObject);
			gameController.AddScore(scoreValue);
		}
	}
}
