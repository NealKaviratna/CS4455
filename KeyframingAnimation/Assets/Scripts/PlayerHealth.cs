using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 200f;
    private Animator animator;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void takeHit(float damage)
    {
        health -= damage;
        if (health <= 0) die();
        else animator.SetTrigger("TakeHit");
    }

    void die()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 3f);
    }
}
