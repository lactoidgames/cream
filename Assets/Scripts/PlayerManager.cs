using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
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
	}

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
			mainManager.AddScore(1);
		}
	}
}
