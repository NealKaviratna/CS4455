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
    private bool doorNearby = false;
    private ParticleSystem ps;
	private bool inAir;

	private PlayerHealth ph;

	public bool IsSettingViaScript;

    //static int roll = Animator.StringToHash("Base Layer.Roll");

	//TODO: Set up states here using nameToHash

	// Use this for initialization
	void Start () {
		ph = GetComponent<PlayerHealth> ();
		animator = GetComponent<Animator> ();
//		capCollider = GetComponent<CapsuleCollider> ();
//		sphereCollider = GetComponent<SphereCollider> ();
		rigidBody = GetComponent<Rigidbody> ();
        charController = GetComponent<CharacterController>();
        lookAtMouse = GetComponent<LookAtMouse>();
        //ps = GetComponentInChildren<ParticleSystem>();
        //ps.enableEmission = false;

		IsSettingViaScript = false;
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
		if (Input.GetAxis("LeftTrigger") > 0.2 && Input.GetAxis("RightTrigger") < 0.1) {
			animator.SetFloat("Speed", 1-Input.GetAxis("LeftTrigger"));
		}
		else {
			animator.SetBool("Walk", false);
		}
		if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton4))//(Input.GetAxis("LeftTrigger") > 0.3f&&Input.GetAxis("RightTrigger") > 0.3f&&!animator.GetBool("Hadouken")))
		{
			Debug.Log(energy);
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).tagHash);
            if (ph.GetEnergy() >= 20 && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Hado"))
            {
                animator.SetBool("Hadouken", true);
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
        
        if (energySlider) energySlider.value = ph.GetEnergy();
		SetAir ();
    }

	void FixedUpdate() {
		Vector3 playerDir = Vector3.ProjectOnPlane(this.transform.forward, Vector3.up);
		Vector3 cameraDir = Vector3.ProjectOnPlane(cameraOrientation.forward, Vector3.up);

		Vector3 inputDir = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		float playerAngle = AngleSigned(playerDir, cameraDir, Vector3.up);

		Vector3 adjustedInput = Quaternion.Euler(0, playerAngle, 0) * inputDir;

		if (animator.enabled && !IsSettingViaScript) {
			animator.SetFloat ("VertSpeed", adjustedInput.z);
			animator.SetFloat ("HorizSpeed", adjustedInput.x);
			animator.SetFloat("Speed", Mathf.Abs(adjustedInput.x) + Mathf.Abs(adjustedInput.z));
			animator.SetFloat("SpeedFactor", Mathf.Lerp(1.0f, 1.4f, Input.GetAxis("RightTrigger")));
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

	public void LookAtTarget(Transform target) {
		Vector3 playerToTarget = target.position - transform.position;
		Vector3 playerForward = transform.forward;

		float angle = AngleSigned(playerToTarget, playerForward, Vector3.up);
		float turn = 0.0f;

		if ( angle < -15)
			turn = 0.5f;
		else if (angle > 15)
			turn = -0.5f;
		
		if (animator.enabled) {
			animator.SetFloat ("VertSpeed", 0);
			animator.SetFloat ("HorizSpeed", 0);
			animator.SetFloat ("HorizSpeed", turn);
			IsSettingViaScript = true;
		}
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

    public void SetDoorNearby(bool b)
    {
        this.doorNearby = b;
    }

	void CheckState() {
		string thisState = "";
//		if (currentState.nameHash == idle)
		Debug.Log ("State = " + thisState);
	}

	public static float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
	{
		return Mathf.Atan2(
			Vector3.Dot(n, Vector3.Cross(v1, v2)),
			Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
	}

	void SetAir()
	{
		Ray r = new Ray(transform.position + Vector3.up, Vector3.down);
		//Ray r2 = new Ray (transform.position + Vector3.up + Vector3.forward, Vector3.down);
		//Ray r3 = new Ray (transform.position + Vector3.up - Vector3.forward, Vector3.down);
		RaycastHit rh = new RaycastHit();
		if (Physics.Raycast (r, out rh, 100f, 1)) {
			Debug.Log (rh.distance);
			if (rh.distance > 1.3f) {
				inAir = true;
			} else {
				inAir = false;
			}
		} else {
			inAir = true;
			Debug.Log ("");
		}
		//if (Physics.Raycast (r2, 1.5f) || Physics.Raycast (r3, 1.5f)) {
		//	inAir = false;
		//}

		animator.SetBool ("InAir", inAir);
	}
}
