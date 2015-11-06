﻿using UnityEngine;
using System.Collections;

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

	void OnCollisionEnter (Collision col)
	{
		Destroy(this.gameObject);
	}
}
