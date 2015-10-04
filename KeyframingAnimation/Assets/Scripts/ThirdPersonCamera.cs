using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public Transform target;
	Transform self;

	
	void Start()
	{
		self = GetComponent<Transform> ();
	}
	
	void LateUpdate()
	{
		self.position = target.position;
	}
}
