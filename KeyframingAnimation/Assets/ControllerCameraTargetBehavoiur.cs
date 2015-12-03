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

	// Use this for initialization
	void Start () {
		xPivotPoint = transform.parent;
		yPivotPoint = xPivotPoint.parent;
		XRot = yPivotPoint.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.IsFree) {
			yPivotPoint.eulerAngles = new Vector3(yPivotPoint.eulerAngles.x, YRot, yPivotPoint.eulerAngles.z);
		}
		else {
			yPivotPoint.localRotation = Quaternion.Lerp(yPivotPoint.localRotation, Quaternion.identity, Time.deltaTime*2);
		}
		xPivotPoint.eulerAngles = new Vector3(this.XRot, xPivotPoint.eulerAngles.y, xPivotPoint.eulerAngles.z);

		defPosition.parent.eulerAngles = new Vector3(this.XRot, defPosition.parent.eulerAngles.y, defPosition.parent.eulerAngles.z);

		XRot += Input.GetAxis("CameraVertical");
		XRot = Mathf.Clamp(XRot, 5, 20);


		Debug.Log(Vector3.Distance(transform.position, defPosition.position));
		float horInput = Input.GetAxis("CameraHorizontal");
		if (!this.IsFree && Mathf.Abs(horInput) > .1f)
			this.IsFree = true;
		else if (this.IsFree && horInput < .1f && Vector3.Distance(transform.position, defPosition.position) < 3)
			this.IsFree = false;
		YRot += horInput * 8;

		if (Input.GetKeyDown(KeyCode.JoystickButton9)) this.IsFree = false;
	}
}
