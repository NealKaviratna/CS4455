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
	
	public Transform cameraOrientation;

    private bool crouched = false;
    private bool isMoving = false;
    private ParticleSystem ps;

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
        //ps = GetComponentInChildren<ParticleSystem>();
        //ps.enableEmission = false;

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
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).tagHash);
            if (energy >= 20 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Hado"))
            {
                animator.SetBool("Hadouken", true);
                energy -= 20f;
                //ps.enableEmission = true;
                //energySlider.value = energy;
            }
        }
		if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton4))//|| (Input.GetJoystickNames().Length >= 1 && Input.GetAxis("LeftTrigger") > 0.3f&&Input.GetAxis("RightTrigger") > 0.3f))
		{
			animator.SetBool("Hadouken", false);
            //ps.enableEmission = false;
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
		Vector3 playerDir = Vector3.ProjectOnPlane(this.transform.forward, Vector3.up);
		Vector3 cameraDir = Vector3.ProjectOnPlane(cameraOrientation.forward, Vector3.up);

		Vector3 inputDir = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		float playerAngle = AngleSigned(playerDir, cameraDir, Vector3.up);

		Vector3 adjustedInput = Quaternion.Euler(0, playerAngle, 0) * inputDir;

		if (animator.enabled) {
			animator.SetFloat ("VertSpeed", adjustedInput.z);
			animator.SetFloat ("HorizSpeed", adjustedInput.x);
		}
        //Debug.Log ("V: " + verticalAxis + " H: " + horizontalAxis);
//
//        if (verticalAxis > 0.1f || verticalAxis < -0.1f)
//        {
//            if (animator.enabled) animator.SetBool("Moving", true);
//            isMoving = true;
//        }
//        else
//        {
//            if (animator.enabled) animator.SetBool("Moving", false);
//            isMoving = false;
//        }
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

	public float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
	{
		return Mathf.Atan2(
			Vector3.Dot(n, Vector3.Cross(v1, v2)),
			Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
	}
}
