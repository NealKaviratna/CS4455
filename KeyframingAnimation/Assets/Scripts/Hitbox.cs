using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {

	public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnCollisionEnter(Collision coll) {
		if (coll.collider.tag == "Enemy") {
			Enemy hitEnemy = coll.gameObject.GetComponent<Enemy>();
			hitEnemy.hP -= damage;
		}
	}
}
