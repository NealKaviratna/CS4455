using UnityEngine;
using System.Collections;

public class ControllerCameraTargetBehavoiur : MonoBehaviour {

	public bool IsFree;
	public float LockingDistance;
	public float Smoothing;

	[Range(5, 25)]
	public float XRot;
	[Range(0,360)]
	public float YRot;
	public Transform defPosition;
	
	private Transform yPivotPoint;
	private Transform xPivotPoint;
	private float playerSpeed;

	private Vector3 temp;

	// Use this for initialization
	void Start () {
		xPivotPoint = transform.parent;
		yPivotPoint = xPivotPoint.parent;
		XRot = yPivotPoint.eulerAngles.x;
		temp = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (this.IsFree) {
			temp.x = yPivotPoint.eulerAngles.x;
			temp.y = YRot;
			Debug.Log (temp.y);
			temp.z = yPivotPoint.eulerAngles.z;
			yPivotPoint.localEulerAngles = temp;
		}
		else {
			this.YRot = 0;
			yPivotPoint.localRotation = Quaternion.Lerp(yPivotPoint.localRotation, Quaternion.identity, Time.deltaTime*2);
		}
		temp.x = this.XRot;
		temp.y = xPivotPoint.eulerAngles.y;
		temp.z = xPivotPoint.eulerAngles.z;

		xPivotPoint.eulerAngles = temp;

		temp.y = defPosition.parent.eulerAngles.y;
		temp.z = defPosition.parent.eulerAngles.z;

		defPosition.parent.eulerAngles = temp;

		XRot += Input.GetAxis("CameraVertical");
		XRot = Mathf.Clamp(XRot, 5, 20);


		float horInput = Input.GetAxis("CameraHorizontal");
		if (!this.IsFree && Mathf.Abs(horInput) > .1f)
			this.IsFree = true;
		else if (this.IsFree && Mathf.Abs(horInput) < .2f && Vector3.Distance(transform.position, defPosition.position) < 3) {
			this.IsFree = false;
		}
		YRot += horInput * 6;

		if (Input.GetKeyDown(KeyCode.JoystickButton9)){ this.IsFree = false;}

		Debug.Log(this.YRot);
	}
}
