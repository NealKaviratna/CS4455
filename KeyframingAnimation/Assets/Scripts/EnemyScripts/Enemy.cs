using UnityEngine;
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

	public string name;

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

	// Use this for initialization
	void Start () {
        IsAlive = true;
        anim = this.GetComponent<Animator>();
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
				scoreManage.addScore(killValue);
                die();
                Debug.Log("dead");
            }
        }
        else
        {
            Debug.Log("Hit " + IsAlive);
            anim.SetTrigger("TakeHit");
        }

		StatusHUD.Enemy = this;
    }

    public void die()
    {
		if (IsAlive) {

			HP = 0f;
			this.IsAlive = false;
			if (sparks != null)
			sparks.enableEmission = true;
			anim.SetTrigger ("Death");
			Destroy (gameObject, 3f);
		}
    }

	void SendToPool() {
        this.transform.position = new Vector3(1000, 1000, 1000);
        this.gameObject.SetActive(false);
	}
}
