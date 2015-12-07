using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 200f;
    private bool isAlive = true;
    public Slider healthSlider;
    private Animator animator;

	private float oldHealth;
	private float newHealth;

	public GameObject healthPart;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
		oldHealth = health;
		newHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		oldHealth = health;
	}

    public void takeHit(float damage)
    {
		if (oldHealth - newHealth < 50f) {
			health -= damage;
			newHealth = health;
			if (health <= 0) {
				if (isAlive)
					die ();
			} else animator.SetTrigger ("TakeHit");
			if (health <= 0)
				healthSlider.value = 0;
			else
				healthSlider.value = health;
		}
    }

    public void getHealth(float h)
    {
        health += h;
        if (health > 200f) health = 200f;
        if (healthSlider) healthSlider.value = health;

		if (healthPart) {
			GameObject hp = Instantiate(healthPart);
			hp.transform.position = this.transform.position;
			hp.transform.rotation = hp.transform.rotation;
			hp.transform.parent = this.transform;
		}
    }

    public void die()
    {
		if (isAlive) {
			health = 0f;
			healthSlider.value = health;
			isAlive = false;
			GetComponent<RobertFootsteps> ().SetUse (false);
            GetComponent<MeleeInput>().enabled = false;
			animator.SetTrigger ("Death");
		}
        //Destroy(gameObject, 3f);
    }
}
