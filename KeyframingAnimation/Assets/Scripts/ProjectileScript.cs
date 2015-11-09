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
public class ProjectileScript : MonoBehaviour {
	
	public Transform heroLoc;
	public Animator heroAnim;
	private float speedScale;
	private float destScale;
	public Transform shooterLoc;
	private Transform myTrans;
	private Vector3 dir;

	
	// Use this for initialization
	void Start () {
		destScale = .59f;
		speedScale = .2f;
		myTrans = GetComponent<Transform> ();
		float dist = Vector3.Distance (shooterLoc.position, heroLoc.position);
		Vector3 dest = heroLoc.position + heroLoc.forward * heroAnim.GetFloat ("VertSpeed") * destScale * dist;
		dir = (dest-shooterLoc.position)/(Vector3.Distance(dest,shooterLoc.position))*speedScale;
		dir.y = 0;

	}
	
	// Update is called once per frame
	void Update () {
		myTrans.position = myTrans.position + dir;
	}

	void OnCollisionEnter (Collision coll)
	{
        GameObject other = coll.gameObject;
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.takeHit(50f);
        }
        Destroy(this.gameObject);
    }
}
