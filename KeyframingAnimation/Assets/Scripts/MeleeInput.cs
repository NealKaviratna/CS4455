using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/** Melee and combat controller
 * @Author: Team Wombo Combo
 *          -Neal Kaviratna
 *          -Robert Borowicz
 *          -Ryan Mendes
 *          -Clay Anderson
 *          -Rich Li
 **/

public class MeleeInput : MonoBehaviour {

	enum Attack {jab, uppercut, kick};
	List<Attack> attackString = new List<Attack>();

    private SmoothAnimScript animScript;

	public float inputCooldown;
	private float inputCooldownlength;

	// TODO: turn on the hitboxes in a better way
	public Collider hitbox1;
	public Collider hitbox2;

	public Animator player;

	// Use this for initialization
	void Start () {
		inputCooldownlength = 0.5f;
		inputCooldown = inputCooldownlength;
        animScript = GetComponent<SmoothAnimScript>();
	}
	
	// Update is called once per frame
	void Update () {
		// Take in user input with a cooldown for time between presses and add them to attack string
		if (inputCooldown < 0) {
			if (Input.GetMouseButtonDown(0)) {
				attackString.Add(Attack.jab);
                inputCooldown = inputCooldownlength;
                animScript.SetCrouched(false);
            }
			else if (Input.GetMouseButtonDown(1)) {
                attackString.Add(Attack.uppercut);
                inputCooldown = inputCooldownlength;
                animScript.SetCrouched(false);
            }
//			else if (Input.GetButtonDown(";"))
//				attackString.Add(Attack.kick);
		}
		inputCooldown -= Time.deltaTime;

		// If the character isn't currently in an attack animation play what's next on attackString
		if (!player.GetCurrentAnimatorStateInfo(1).IsTag("attack") && attackString.Count > 0) {
			Attack next = attackString[0];
			player.SetInteger("NextAttack", ((int)next) + 1);
			Debug.Log(attackString.Count);
			attackString.Remove(next);
			Debug.Log(next);
		}
		else if(player.GetCurrentAnimatorStateInfo(1).IsTag("attack")) {
			player.SetInteger("NextAttack", 0);
			hitbox1.enabled = true;
			hitbox2.enabled = true;
		}
		else {
			hitbox1.enabled = false;
			hitbox2.enabled = false;
		}
	}
}
