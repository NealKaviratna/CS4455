using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	public PlayerHealth ph;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			ph.die();
		}
	}
}
