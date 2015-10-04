//Written by Robert Borowicz
//Place this on a parent camera object and make the target a transform

using UnityEngine;
using System.Collections;

public class FollowerCamera : MonoBehaviour {
	
	public Transform target;
	public float dist_back = 5f;
	public float dist_up = 5f;
	public float smoothing = 2;
	Vector3 followTarget;
	
	void Start()
	{}
	
	void LateUpdate()
	{
		if (!target) return;
		float target_height = target.position.y + dist_up;
		float curr_height = transform.position.y;
		float new_height = Mathf.Lerp(curr_height, target_height, smoothing * Time.deltaTime);
		
		transform.position = target.position;
		transform.position -= Vector3.forward * dist_back;
		Vector3 temp = transform.position;
		temp.y = new_height;
		transform.position = temp;
		transform.LookAt(target);
	}
}
