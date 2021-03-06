﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	private GameObject player;
	public float smoothTime = 1f;
	private Transform thisTransform;
	private Vector2 velocity;
	
	void Start()
	{
		player = GameObject.Find ("player");
		thisTransform = transform;
	}
	
	void Update() 
	{
		Vector3 vec = thisTransform.position;
		vec.x = Mathf.SmoothDamp( thisTransform.position.x, 
		                         player.transform.position.x, ref velocity.x, smoothTime);
		vec.y = Mathf.SmoothDamp( thisTransform.position.y, 
		                         player.transform.position.y, ref velocity.y, smoothTime);
		thisTransform.position = vec;

		thisTransform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.09F, 3.09F), 
		                                 Mathf.Clamp(transform.position.y, -3.06F, 3.06F), -10);
	}
}
