﻿using UnityEngine;
using System.Collections;

public class SmoothAnimScript : MonoBehaviour {

	private Animator animator;
	private CapsuleCollider capCollider;
    private CharacterController charController;
	private SphereCollider sphereCollider;
	private Rigidbody rigidBody;
	private AnimatorStateInfo currentState;
    private LookAtMouse lookAtMouse;

    private bool crouched = false;

    static int diveJump = Animator.StringToHash("Base Layer.Dive Jump");

	//TODO: Set up states here using nameToHash

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
//		capCollider = GetComponent<CapsuleCollider> ();
//		sphereCollider = GetComponent<SphereCollider> ();
		rigidBody = GetComponent<Rigidbody> ();
        charController = GetComponent<CharacterController>();
        lookAtMouse = GetComponent<LookAtMouse>();

    }
	
	// Update is called once per frame
	void Update () {
		currentState = animator.GetCurrentAnimatorStateInfo(0); //Get the current state
//		if (Input.GetButtonUp ("Jump")) { //TODO: change this from jump to a dedicated crouch button
//			animator.SetBool("Crouched", !animator.GetBool("Crouched"));
//		}
		if (Input.GetButtonUp ("Jump")) {
			animator.SetTrigger("Jump");
		}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Roll");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            crouched = !crouched;
            animator.SetBool("Crouched", crouched);
            if (crouched)
            {
                charController.height = .97f;
                Vector3 newCenter = charController.center;
                newCenter.y = .49f;
                charController.center = newCenter;
            }
            else
            {
                charController.height = 1.77f;
                Vector3 newCenter = charController.center;
                newCenter.y = .9f;
                charController.center = newCenter;
            }
        }

        // Temporary code for ragdoll testing
        if (Input.GetKeyDown("r"))
        {
            animator.enabled = !animator.enabled;
            lookAtMouse.enabled = !lookAtMouse.enabled;
        }
    }

	void FixedUpdate() {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		animator.SetFloat ("VertSpeed", verticalAxis);
		animator.SetFloat ("HorizSpeed", horizontalAxis);
        //Debug.Log ("V: " + verticalAxis + " H: " + horizontalAxis);

        if (horizontalAxis > 0.1f || horizontalAxis < -0.1f || verticalAxis > 0.1f || verticalAxis < -0.1f)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        /*if (currentState.fullPathHash == diveJump)
        {
            if (!animator.IsInTransition(0))
            {
                charController.height = animator.GetFloat("ColliderHeight");
            }
        }*/
	}

	void CheckState() {
		string thisState = "";
//		if (currentState.nameHash == idle)
		Debug.Log ("State = " + thisState);
	}
}
