using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeInput : MonoBehaviour {

	enum Attack {jab, cross, uppercut, kick};
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
			if (Input.GetMouseButtonDown(0))
				attackString.Add(Attack.jab);
			else if (Input.GetMouseButtonDown(1))
				attackString.Add(Attack.cross);
			else if (Input.GetButtonDown("l"))
				attackString.Add(Attack.uppercut);
			else if (Input.GetButtonDown(";"))
				attackString.Add(Attack.kick);
			inputCooldown = 0.5f;
		}
		inputCooldown -= Time.deltaTime;

		// If the character isn't currently in an attack animation play what's next on attackString
		if (!player.GetCurrentAnimatorStateInfo(1).IsTag("attack")) {
			player.SendMessage(attackString[0].ToString());
			attackString.RemoveAt(0);
		}

		Debug.Log(attackString[0].ToString());
	}
}
