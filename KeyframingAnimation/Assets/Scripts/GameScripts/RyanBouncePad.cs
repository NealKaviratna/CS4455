using UnityEngine;
using System.Collections;

public class RyanBouncePad : MonoBehaviour {

	public float power = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.GetComponent<Rigidbody> ();
		rb.AddForce (transform.up * power, ForceMode.Impulse);
	}
}
