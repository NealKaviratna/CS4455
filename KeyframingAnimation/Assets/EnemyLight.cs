using UnityEngine;
using System.Collections;

public class EnemyLight : MonoBehaviour {

	public Light spot;
	Color YELLOW;
	Color RED;

	// Use this for initialization
	void Start () {
		//spot = GetComponent<Light> ();
		YELLOW = new Color (246, 255, 167);
		RED = new Color (255, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		Debug.Log ("FoundObject");
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("FoundPlayer");
			spot.color = RED;
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			spot.color = YELLOW;
		}
	}
}
