﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float hP;
	public float attack;
	public bool isAlive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (this.hP <= 0) {
			// This thing dies TODO: add animation/call to death
			this.SendToPool();
		}
	}

	void SendToPool() {
		this.transform.position = new Vector3(1000,1000,1000);
		this.isAlive = false;
		this.gameObject.SetActive(false);
	}
}