using UnityEngine;
using System.Collections;

public class WallBreakScript : MonoBehaviour {


	public Transform sphere;
	private Vector3 pos;
	public float thresh;
	public AudioClip crash;
	private bool crashed;
	private AudioSource source;
	// Use this for initialization
	void Start () {
		pos = GetComponent<Transform> ().position;
		source = GetComponent<AudioSource> ();
		crashed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!crashed) {
			if (Vector3.Distance (pos, sphere.position) < thresh) {
				Destroy(gameObject.GetComponent<FixedJoint>());
				source.PlayOneShot(crash,1f);
				crashed = true;
			}
		}
	}
}
