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
    private bool attacking = false;

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
			// Pass block for hadouken
			if (Input.GetAxis("LeftTrigger") > 0.3f && Input.GetAxis("RightTrigger") > 0.3f);
			else if (Input.GetMouseButtonDown(0) || Input.GetAxis("RightTrigger") > 0.3f) {
				attackString.Add(Attack.jab);
                inputCooldown = inputCooldownlength;
                animScript.SetCrouched(false);
            }
			else if (Input.GetMouseButtonDown(1) || Input.GetAxis("LeftTrigger") > 0.3f) {
                attackString.Add(Attack.uppercut);
                inputCooldown = inputCooldownlength;
                animScript.SetCrouched(false);
            }
			else if (Input.GetKeyDown("f") || Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                attackString.Add(Attack.kick);
                inputCooldown = inputCooldownlength;
                animScript.SetCrouched(false);
            }
			    
		}
		inputCooldown -= Time.deltaTime;

		// If the character isn't currently in an attack animation play what's next on attackString
		if (!player.GetCurrentAnimatorStateInfo(1).IsTag("attack") && attackString.Count > 0) {
			Attack next = attackString[0];
			player.SetInteger("NextAttack", ((int)next) + 1);
//			Debug.Log(attackString.Count);
			attackString.Remove(next);
            GetComponent<RobertFootsteps>().SetUse(false);
            setAttacking(true);
        }
		else if(player.GetCurrentAnimatorStateInfo(1).IsTag("attack")) {
			player.SetInteger("NextAttack", 0);
			//hitbox1.enabled = true;
			//hitbox2.enabled = true;
            GetComponent<RobertFootsteps>().SetUse(false);
            setAttacking(true);
        }
		else {
			//hitbox1.enabled = false;
			//hitbox2.enabled = false;
            GetComponent<RobertFootsteps>().SetUse(true);
            setAttacking(true);
        }
	}

    public void setAttacking(bool b)
    {
        this.attacking = b;
    }

    public bool getAttacking()
    {
        return this.attacking;
    }
}
