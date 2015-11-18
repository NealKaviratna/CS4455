using UnityEngine;
using System.Collections;

/**
 * @Author: Team Wombo Combo
 *          -Neal Kaviratna
 *          -Robert Borowicz
 *          -Ryan Mendes
 *          -Clay Anderson
 *          -Rich Li
 **/

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
			hitEnemy.HP -= damage;
            hitEnemy.Hit = true;
		}
	}

    void OnCollisionExit(Collision coll)
    {
        inColl = false;
    }
}
