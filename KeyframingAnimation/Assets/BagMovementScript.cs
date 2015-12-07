using UnityEngine;
using System.Collections;

public class BagMovementScript : MonoBehaviour {
	
	public Transform left_lim;
	public Transform right_lim;
	public float length;
	private Vector3 direc;
	private bool left_right;

	// Use this for initialization
	void Start () {
		//direction = -1f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp (left_lim.position, right_lim.position, Mathf.PingPong((Time.realtimeSinceStartup)/length, 1));
	}
}
