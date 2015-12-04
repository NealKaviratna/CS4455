using UnityEngine;
using System.Collections;

public class AcidKill : MonoBehaviour {

	//public PlayerHealth health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {

		GameObject other = coll.gameObject;

		//Enemy enemyScript = other.GetComponentInParent<Enemy> ();
		PlayerHealth healthScript = other.GetComponentInParent<PlayerHealth> ();

		/*if (enemyScript) {
			enemyScript.die ();
		}*/
		if (healthScript) {
			healthScript.die ();
		}
	}
}
