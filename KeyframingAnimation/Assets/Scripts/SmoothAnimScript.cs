using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/** User input and character controller
 * @Author: Team Wombo Combo
 *          -Neal Kaviratna
 *          -Robert Borowicz
 *          -Ryan Mendes
 *          -Clay Anderson
 *          -Rich Li
 **/

public class SmoothAnimScript : MonoBehaviour {

	public Animator animator;
	//private CapsuleCollider capCollider;
    private CharacterController charController;
	private SphereCollider sphereCollider;
	private Rigidbody rigidBody;
	//private AnimatorStateInfo currentState;
    private LookAtMouse lookAtMouse;

    public Slider energySlider;
    public float energy;

    private bool crouched = false;
    private bool isMoving = false;

    //static int roll = Animator.StringToHash("Base Layer.Roll");

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

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        //currentState = animator.GetCurrentAnimatorStateInfo(0); //Get the current state
        //		if (Input.GetButtonUp ("Jump")) { //TODO: change this from jump to a dedicated crouch button
        //			animator.SetBool("Crouched", !animator.GetBool("Crouched"));
        //		}
        /*if (Input.GetButtonUp ("Jump")) {
			animator.SetTrigger("Jump");
		}*/

        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Roll");
        }*/

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton8))
        {
            SetCrouched(!crouched);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
        }
        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("Jump", false);
        }
		if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton4))//(Input.GetAxis("LeftTrigger") > 0.3f&&Input.GetAxis("RightTrigger") > 0.3f&&!animator.GetBool("Hadouken")))
		{
			Debug.Log(energy);
            if (energy >= 20)
            {
                animator.SetBool("Hadouken", true);
                energy -= 20f;
                //energySlider.value = energy;
            }
        }
		if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton4))//|| (Input.GetJoystickNames().Length >= 1 && Input.GetAxis("LeftTrigger") > 0.3f&&Input.GetAxis("RightTrigger") > 0.3f))
		{
			animator.SetBool("Hadouken", false);
        }

        // Temporary code for ragdoll testing
        if (Input.GetKeyDown("r"))
        {
            animator.enabled = !animator.enabled;
            lookAtMouse.enabled = !lookAtMouse.enabled;
        }
        energy += Time.deltaTime*2;
        if (energy > 100) energy = 100;
        if (energySlider) energySlider.value = energy;
    }

	void FixedUpdate() {
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		if (animator.enabled) {
			animator.SetFloat ("VertSpeed", verticalAxis);
			animator.SetFloat ("HorizSpeed", horizontalAxis);
		}
        //Debug.Log ("V: " + verticalAxis + " H: " + horizontalAxis);

        if (verticalAxis > 0.1f || verticalAxis < -0.1f)
        {
            if (animator.enabled) animator.SetBool("Moving", true);
            isMoving = true;
        }
        else
        {
            if (animator.enabled) animator.SetBool("Moving", false);
            isMoving = false;
        }

        /*if (currentState.fullPathHash == roll)
        {
            if (!animator.IsInTransition(0))
            {
                charController.height = animator.GetFloat("ColliderHeight");
            }
        }*/
	}

    public bool GetMoving()
    {
        return isMoving;
    }

    public bool GetCrouched()
    {
        return crouched;
    }

    public void SetCrouched(bool c)
    {
        crouched = c;
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

	void CheckState() {
		string thisState = "";
//		if (currentState.nameHash == idle)
		Debug.Log ("State = " + thisState);
	}
}
