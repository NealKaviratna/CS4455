﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	public string e_name;

	public float HP;
	public float MaxHP;

	public int killValue;

	public ScoreManager scoreManage;

	private float Attack;
	public bool IsAlive;
    public bool Hit;

	public Sprite Portrait;
	public EnemyStatusDisplayController StatusHUD;

    public ParticleSystem sparks;
    public ParticleSystem smoke;

    public AudioClip hitSound;
	public AudioClip dieSound;
    private AudioSource audio_s;

	// Use this for initialization
	void Start () {
        IsAlive = true;
        anim = this.GetComponent<Animator>();
        audio_s = GetComponent<AudioSource>();
        Hit = false;
		MaxHP = HP;
        if (sparks != null) sparks.enableEmission = false;
        if (smoke != null) smoke.enableEmission = false;
	}

    public void takeHit(float damage)
    {

        HP -= damage;
        if (HP <= 50 && smoke != null) smoke.enableEmission = true;
        if (HP <= 0)
        {
            if (IsAlive)
            {
				if (scoreManage != null)
					scoreManage.addScore(killValue);
				if (anim != null)
	                die();
                Debug.Log("dead");
            }
        }
        else
        {
            if (hitSound) audio_s.PlayOneShot(hitSound, .7f);
            Debug.Log("Hit " + IsAlive);
			if (anim != null)
	            anim.SetTrigger("TakeHit");
        }
		StatusHUD.Enemy = this;
    }

    public void die()
    {
		if (IsAlive) {
			if (dieSound != null && audio_s)audio_s.PlayOneShot(dieSound, .5f);
			HP = 0f;
			this.IsAlive = false;
			if (sparks != null)
				sparks.enableEmission = true;
			anim.SetTrigger ("Death");
			Destroy (gameObject, 3f);
		}
    }
}
