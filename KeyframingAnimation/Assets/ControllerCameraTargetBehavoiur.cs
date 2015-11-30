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
			yPivotPoint.rotation = Quaternion.Lerp(yPivotPoint.rotation, Quaternion.identity, Time.deltaTime*Smoothing);
		}
		xPivotPoint.eulerAngles = new Vector3(this.XRot, xPivotPoint.eulerAngles.y, xPivotPoint.eulerAngles.z);

		//defPosition.eulerAngles = new Vector3(this.XRot, defPosition.eulerAngles.y, defPosition.eulerAngles.z);

		XRot += Input.GetAxis("CameraVertical");
		XRot = Mathf.Clamp(XRot, 5, 25);

		float horInput = Input.GetAxis("CameraHorizontal");
		if (!this.IsFree && horInput > .1f)
			this.IsFree = true;
		else if (this.IsFree && horInput > .1f && Vector3.Distance(transform.position, defPosition.position) < .1f)
			this.IsFree = false;
		YRot += horInput * 5;
	}
}
