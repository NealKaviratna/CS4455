using UnityEngine;
using System.Collections;

public class RyanBoxPlatformMover : MonoBehaviour {

	public AudioClip clip;
	public GameObject boxPlatform;
	public GameObject targetObject;
	private Rigidbody rb;
	private bool startMoving = false;
	public float speed = 3.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (startMoving == true) {
			boxPlatform.transform.position = Vector3.MoveTowards(boxPlatform.transform.position, targetObject.transform.position, speed);
		}
	}

	void OnTriggerEnter() {
		rb.isKinematic = false;
		startMoving = true;
		AudioSource.PlayClipAtPoint (clip, gameObject.transform.position, 1.0f);
	}
}
