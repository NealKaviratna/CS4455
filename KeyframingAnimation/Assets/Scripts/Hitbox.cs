using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {

	public float damage;
    bool inColl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnCollisionEnter(Collision coll) {
		if (coll.collider.tag == "Enemy" && !inColl) {
            inColl = true;
			Enemy hitEnemy = coll.gameObject.GetComponent<Enemy>();
			hitEnemy.hP -= damage;
            hitEnemy.hit = true;
		}
	}

    void OnCollisionExit(Collision coll)
    {
        inColl = false;
    }
}
