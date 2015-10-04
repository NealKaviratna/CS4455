using UnityEngine;
using System.Collections;

public class SmoothAnimScript : MonoBehaviour {

	private Animator animator;
	private CapsuleCollider capCollider;
	private SphereCollider sphereCollider;
	private Rigidbody rigidBody;
	private AnimatorStateInfo currentState;

	//TODO: Set up states here using nameToHash

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
//		capCollider = GetComponent<CapsuleCollider> ();
//		sphereCollider = GetComponent<SphereCollider> ();
		rigidBody = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		currentState = animator.GetCurrentAnimatorStateInfo(0); //Get the current state
		if (Input.GetButtonUp ("Jump")) { //TODO: change this from jump to a dedicated crouch button
			animator.SetBool("Crouched", !animator.GetBool("Crouched"));
		}
	
	}

	void FixedUpdate() {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		animator.SetFloat ("VertSpeed", verticalAxis);
		animator.SetFloat ("HorizSpeed", horizontalAxis);
		Debug.Log ("V: " + verticalAxis + " H: " + horizontalAxis);

		if (horizontalAxis > 0.1f || horizontalAxis < -0.1f || verticalAxis > 0.1f || verticalAxis < -0.1f) {
			animator.SetBool ("Moving", true);
		} else
			animator.SetBool ("Moving", false);

	}

	void CheckState() {
		string thisState = "";
//		if (currentState.nameHash == idle)
		Debug.Log ("State = " + thisState);
	}
}
