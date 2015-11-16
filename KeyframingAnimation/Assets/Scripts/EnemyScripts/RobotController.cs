/*using UnityEngine;
using System.Collections;

/**
 * @Author: Team Wombo Combo
 *          -Neal Kaviratna
 *          -Robert Borowicz
 *          -Ryan Mendes
 *          -Clay Anderson
 *          -Rich Li
 **/

/*public class RobotController : MonoBehaviour {

	private Animator animator;
	private CapsuleCollider capCollider;
	private SphereCollider sphereCollider;
	private Rigidbody rigidBody;
	private AnimatorStateInfo currentState;
	
	public float animationSpeed = 1.0f; //This is the speed at which the animation plays. Set to animator.speed
	public float jumpForce = 1.2f;
	private float startingCapColliderHeight;

	//States
	static int idle = Animator.StringToHash("Base Layer.Idle");
	static int idleCrouch = Animator.StringToHash("Base Layer.IdleCrouch");
	static int move = Animator.StringToHash("Base Layer.WalkJogRun");
	static int crouchMove = Animator.StringToHash ("Base Layer.WalkCrouch");
	static int backpedal = Animator.StringToHash("Base Layer.WalkBackwards");
	static int crouchBackpedal = Animator.StringToHash ("WalkBackwardsCrouch");
	static int jump = Animator.StringToHash("Base Layer.Jumping");

	
	void Start () {
		animator = GetComponent<Animator> ();
		capCollider = GetComponent<CapsuleCollider> ();
		sphereCollider = GetComponent<SphereCollider> ();
		rigidBody = GetComponent<Rigidbody> ();
		startingCapColliderHeight = capCollider.height;
	}
	
	// Update is called once per frame
	void Update () {
		currentState = animator.GetCurrentAnimatorStateInfo(0); //Get the current state
		bool crouched = animator.GetBool ("Crouch");
		if (currentState.nameHash == move) { //If we're in move
			if (Input.GetButtonUp ("Jump") || Input.GetButtonUp("Fire2")) {
				animator.SetTrigger ("Jump"); //Changed from SetBool
//				sphereCollider.center.y = animator.GetFloat("ColliderHeight"); //WHY CANT I CHANGE THIS
				rigidBody.AddForce (Vector3.up * jumpForce);
			}
		}
		if(Input.GetButtonUp("Fire1"))
		{
			animator.SetBool("Crouch", !crouched);
		}
	}

	void FixedUpdate() {
		//checkForState ();
		capColliderCorrect ();
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		animator.SetFloat ("Speed", verticalAxis);

		//if jumping, adjust the collider
		if (currentState.nameHash == jump) {
			//If animation is not transitioning
			if(!animator.IsInTransition(0)) {
				capCollider.height= animator.GetFloat("ColliderHeight");
				rigidBody.useGravity = false;
				float balls  = animator.GetFloat("ColliderHeight");
				Debug.Log (animator.gravityWeight);
			}
		}
//		if (currentState.nameHash == idleCrouch || currentState.nameHash == crouchMove || currentState.nameHash == crouchBackpedal) {
//			sphereCollider.enabled = true;
//			capCollider.enabled = false;
//		} else {
//			capCollider.enabled = true;
//			sphereCollider.enabled = false;
//		}



	}

	void checkForState() {
		string thisState = "";
		if (currentState.nameHash == idle)
			thisState = "idle";
		else if (currentState.nameHash == idleCrouch) 
			thisState = "idle crouch";
		else if (currentState.nameHash == move) 
			thisState = "move";
		else if (currentState.nameHash == crouchMove) 
			thisState = "crouch moving";
		else if (currentState.nameHash == backpedal) 
			thisState = "backpedalling";
		else if (currentState.nameHash == crouchBackpedal) 
			thisState = "crouch backpedalling";
		else if (currentState.nameHash == jump) 
			thisState = "jump";
		else
			thisState = "NONE OF THESE WHAT THE FUCK";
		Debug.Log("current state: " + thisState);
	}

	void capColliderCorrect() {
		if (currentState.nameHash != jump) {
			capCollider.height = startingCapColliderHeight;
			rigidBody.useGravity = true;
		}
	}
}*/
