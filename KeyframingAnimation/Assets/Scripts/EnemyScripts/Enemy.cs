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

	public float Attack;
	public bool IsAlive;
    public bool Hit;

	public Sprite Portrait;
	public EnemyStatusDisplayController StatusHUD;

	// Use this for initialization
	void Start () {
        IsAlive = true;
        anim = this.GetComponent<Animator>();
        Hit = false;
		MaxHP = HP;
	}

    public void takeHit(float damage)
    {

        HP -= damage;
        if (HP <= 0)
        {
            if (IsAlive)
            {
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

    void die()
    {
        this.IsAlive = false;
        anim.SetTrigger("Death");
        Destroy(gameObject, 3f);
    }

	void SendToPool() {
        this.transform.position = new Vector3(1000, 1000, 1000);
        this.gameObject.SetActive(false);
	}
}
