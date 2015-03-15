using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
	private MainManager mainManager;
	private Animator animator;
	private Animation anim;

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

		//get reference to Animator and Animation components
		animator = GetComponent<Animator> ();
		anim = GetComponent<Animation> ();
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
		while(Vector3.Distance(transform.position, target) > 0.05f)
		{
			animator.SetBool ("isIdle", false);

			if (target.y < transform.position.y && (Mathf.Abs(transform.position.x - target.x) < Mathf.Abs(transform.position.y - target.y)))
			{
				animator.SetTrigger("TrigDown");
			}
			if (target.y > transform.position.y && (Mathf.Abs(transform.position.x - target.x) < Mathf.Abs(transform.position.y - target.y)))
			{
				animator.SetTrigger("TrigUp");
			}
			if (target.x > transform.position.x && (Mathf.Abs(transform.position.x - target.x) > Mathf.Abs(transform.position.y - target.y)))
			{
				animator.SetTrigger("TrigRight");
			}
			if (target.x < transform.position.x && (Mathf.Abs(transform.position.x - target.x) > Mathf.Abs(transform.position.y - target.y)))
			{
				animator.SetTrigger("TrigLeft");
			}

			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
			yield return null;
		}

		animator.SetBool ("isIdle", true);
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "coin")
		{
			coll.gameObject.SetActive(false);
			mainManager.AddScore(1);
		}
		if (coll.gameObject.tag == "car")
		{
			anim.CrossFade("Hit");
		}
	}
}
