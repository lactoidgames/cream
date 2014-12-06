using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	
	public Transform target;
	public float smoothTime = 1f;
	private Transform thisTransform;
	private Vector2 velocity;
	
	private void Start()
	{
		thisTransform = transform;
	}
	
	private void Update() 
	{
		Vector3 vec = thisTransform.position;
		vec.x = Mathf.SmoothDamp( thisTransform.position.x, 
		                         target.position.x, ref velocity.x, smoothTime);
		vec.y = Mathf.SmoothDamp( thisTransform.position.y, 
		                         target.position.y, ref velocity.y, smoothTime);
		thisTransform.position = vec;

		thisTransform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.29F, 7.29F), 
		                                 Mathf.Clamp(transform.position.y, -1.95F, 1.95F), -10);
	}
}
