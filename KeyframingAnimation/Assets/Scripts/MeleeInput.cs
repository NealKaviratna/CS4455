using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeInput : MonoBehaviour {

	enum Attack {jab, uppercut, kick};
	List<Attack> attackString = new List<Attack>();

	public float inputCooldown;

	public Animator player;

	// Use this for initialization
	void Start () {
		inputCooldown = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		// Take in user input with a cooldown for time between presses and add them to attack string
		if (inputCooldown < 0) {
			if (Input.GetMouseButtonDown(0)) {
				attackString.Add(Attack.jab);  inputCooldown = 0.5f; }
			else if (Input.GetMouseButtonDown(1)) {
				attackString.Add(Attack.uppercut); inputCooldown = 0.5f; }
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
		else if(player.GetCurrentAnimatorStateInfo(1).IsTag("attack"))
			player.SetInteger("NextAttack", 0);
	}
}
