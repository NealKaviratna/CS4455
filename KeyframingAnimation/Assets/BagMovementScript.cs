using UnityEngine;
using System.Collections;

public class BagMovementScript : MonoBehaviour {

	private float direction;

	// Use this for initialization
	void Start () {
		direction = -1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < 8.5f || this.transform.position.x > 27f) {
			direction *= -1f;
		}
		this.transform.Translate (new Vector3 (3f * direction * Time.deltaTime, 0, 0));
	}
}
