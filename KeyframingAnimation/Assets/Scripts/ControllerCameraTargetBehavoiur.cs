using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerCameraTargetBehavoiur : MonoBehaviour {

	public bool IsFree;
	public float LockingDistance;
	public float Smoothing;

	[Range(5, 25)]
	public float XRot;
	[Range(0,360)]
	public float YRot;
	public Transform defPosition;

	public GameObject ZTarget;
	public List<GameObject> PotentialZTargets;
	public bool Zlocked;
	
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

		PotentialZTargets = new List<GameObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Zlocked) {
			NormalCameraUpdate();
			ZTargetUpdate();
		}
		else {
			ZLockedUpdate();
		}

		if (Input.GetKeyDown(KeyCode.JoystickButton9)){
			if (this.ZTarget == null)
				this.IsFree = false;
			else
				this.Zlocked = !this.Zlocked;
		}
	}


	void NormalCameraUpdate() {
		if (this.IsFree) {
			temp.x = yPivotPoint.eulerAngles.x;
			temp.y = YRot;
			temp.z = yPivotPoint.eulerAngles.z;
			yPivotPoint.eulerAngles = temp;
		}
		else {
			this.YRot = yPivotPoint.eulerAngles.y;
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
	}

	void ZTargetUpdate() {
		float minDistance = float.PositiveInfinity;
		if (ZTarget != null) ZTarget.transform.GetChild(0).gameObject.SetActive(false);
		ZTarget = null;
		foreach (GameObject zT in PotentialZTargets) {
			float dist = Vector3.Distance(yPivotPoint.position, zT.transform.position);

			RaycastHit hit;

			if (dist < minDistance && Physics.Raycast(transform.position, zT.transform.position -transform.position, out hit, 100, 1) && hit.collider.gameObject == zT) {
				minDistance = dist;
				ZTarget = zT;
			}
		}
		if (ZTarget != null) ZTarget.transform.GetChild(0).gameObject.SetActive(true);
	}

	void ZLockedUpdate() {

	}
}
