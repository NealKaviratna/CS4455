using UnityEngine;
using System.Collections;

public class BallRollingSound : MonoBehaviour {

	private AudioSource source;
	private Vector3 prev;
	private Transform trans;
	public float thresh;
	private float dist;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		trans = GetComponent<Transform> ();
		prev = trans.position;
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance(prev, transform.position);
		if (dist > thresh) {
			source.volume = Mathf.Min (dist * 3, 1);
		} else {
			source.volume = 0;
		}
		prev = trans.position;

	}
}
