using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 200f;
    private bool isAlive = true;
    public Slider healthSlider;
    private Animator animator;

	public GameObject healthPart;

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
        if (health <= 0)
        {
            if (isAlive) die();
        }
        else animator.SetTrigger("TakeHit");
        if (health <= 0) healthSlider.value = 0;
        else healthSlider.value = health;
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

    void die()
    {
        isAlive = false;
        GetComponent<RobertFootsteps>().SetUse(false);
        animator.SetTrigger("Death");
        //Destroy(gameObject, 3f);
    }
}
