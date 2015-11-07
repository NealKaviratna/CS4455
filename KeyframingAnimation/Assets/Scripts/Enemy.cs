﻿using UnityEngine;
using System.Collections;

/**
 * @Author: Team Wombo Combo
 *          -Neal Kaviratna
 *          -Robert Borowicz
 *          -Ryan Mendes
 *          -Clay Anderson
 *          -Rich Li
 **/

public class Enemy : MonoBehaviour {

    Animator anim;

	public float hP;
	public float attack;
	public bool isAlive;
    public bool hit;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        hit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.hP <= 0) {
            // This thing dies TODO: add animation/call to death
            anim.SetTrigger("Death");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                Debug.Log("Death");
                this.SendToPool();
            }
		}
        anim.SetBool("Hit", hit);
        if (hit)
            hit = false;
	}

	void SendToPool() {
        this.transform.position = new Vector3(1000, 1000, 1000);
        this.isAlive = false;
        this.gameObject.SetActive(false);
	}
}
