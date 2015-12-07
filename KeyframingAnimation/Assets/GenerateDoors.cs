using UnityEngine;
using System.Collections;

public class GenerateDoors : MonoBehaviour {

	private DoorOpen door;

	// Use this for initialization
	void Start () {
		door = GetComponentInChildren<DoorOpen> ();
		int rand_value = Random.Range(0, 2);
		if (rand_value == 0) {
			int broken = Random.Range (0, 4);
			if (broken == 0) {
				door.isBroken = true;
				door.SetPosition(1.25f);
			}
		} else {
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
