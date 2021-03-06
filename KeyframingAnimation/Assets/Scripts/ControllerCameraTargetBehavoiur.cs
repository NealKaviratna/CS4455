﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

	public Transform ZLockCamerPos;
	public Transform ZLockLookPos;

	public ControllerCameraFollowBehaviour CCFB;

	private Transform playerTrans;
	private Transform yPivotPoint;
	private Transform xPivotPoint;
	private float playerSpeed;

	private Vector3 temp;

	// Use this for initialization
	void Start () {
		xPivotPoint = transform.parent;
		yPivotPoint = xPivotPoint.parent;
		XRot = yPivotPoint.eulerAngles.x;
		XRot = 12;
		temp = Vector3.zero;

		PotentialZTargets = new List<GameObject>();

		playerTrans =  yPivotPoint.parent;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.JoystickButton9) || Input.GetKeyDown(KeyCode.I)){
			if (this.ZTarget == null)
				this.IsFree = false;
			else {
				if (this.Zlocked)
					DeZLock();
				else
					ZLock();
			}
		}

		if (!Zlocked) {
			NormalCameraUpdate();
			ZTargetUpdate();
		}
		else {
			ZLockedUpdate();
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

		ZLockLookPos.position = Vector3.MoveTowards(ZLockLookPos.position, yPivotPoint.position, .2f);

		if (!CCFB.isOriginalLook()) {
			if ( Vector3.Distance(ZLockLookPos.position, yPivotPoint.position) < 0.04f)
				CCFB.ResetLook();
		}


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
			if (zT != null && zT.GetComponent<Enemy>().IsAlive) {
				float dist = Vector3.Distance(yPivotPoint.position, zT.transform.position);

				RaycastHit hit;
				if (dist < minDistance && Physics.Raycast(transform.position, zT.transform.position -transform.position , out hit, 100, 1) && hit.collider.gameObject.GetComponentInParent<Enemy>() != null && hit.collider.gameObject.GetComponentInParent<Enemy>().gameObject == zT) {
					minDistance = dist;
					ZTarget = zT;
				}
			}
		}
		if (ZTarget != null) ZTarget.transform.GetChild(0).gameObject.SetActive(true);
	}

	void ZLockedUpdate() {
		if (ZTarget == null ) {//|| !ZTarget.GetComponent<Enemy>().IsAlive) {
			DeZLock();
		}
		else {
			temp.x = yPivotPoint.eulerAngles.x;
			temp.y = YRot;
			temp.z = yPivotPoint.eulerAngles.z;
			yPivotPoint.eulerAngles = temp;

			this.ZLockLookPos.position = Vector3.Lerp( yPivotPoint.transform.position, ZTarget.transform.position, 0.5f);
			Vector3 cameraToTarget = ZTarget.transform.position - transform.position;
			Vector3 cameraToPlayer = yPivotPoint.position - transform.position;

			Vector3.ProjectOnPlane(cameraToTarget, Vector3.up);
			Vector3.ProjectOnPlane(cameraToPlayer, Vector3.up);

			float angle = Vector3.Angle(cameraToTarget, cameraToPlayer);

			if ( angle >= 45) {
				Vector3.MoveTowards(this.transform.position, this.transform.forward, 0.5f);
			}
			else if ( angle < 40) {
				Vector3.MoveTowards(this.transform.position, -1 * this.transform.forward, 0.5f);
			}

			if (Mathf.Abs(Input.GetAxis ("Horizontal")) + Mathf.Abs(Input.GetAxis ("Vertical")) < 0.05) {
				playerTrans.gameObject.GetComponent<SmoothAnimScript>().LookAtTarget(ZTarget.transform);
			}
			else {
				playerTrans.gameObject.GetComponent<SmoothAnimScript>().IsSettingViaScript = false;
			}
		}
	}

	void ZLock() {
		ZTarget.GetComponentInChildren<Image>().color = new Color(255, 255, 0);
		this.Zlocked = true;
		this.ZLockLookPos.position = Vector3.Lerp( yPivotPoint.transform.position, ZTarget.transform.position, 0.5f);
		this.CCFB.lookTarget = this.ZLockLookPos;
		
		temp.x = yPivotPoint.eulerAngles.x;
		temp.y = YRot;
		temp.z = yPivotPoint.eulerAngles.z;
		yPivotPoint.eulerAngles = temp;

		GetComponentInParent<FireHadouken>().trackTarget = ZTarget.transform;
	}

	void DeZLock() {
		if (ZTarget != null)  ZTarget.GetComponentInChildren<Image>().color = new Color(255, 255, 255);
		this.Zlocked = false;
		playerTrans.gameObject.GetComponent<SmoothAnimScript>().IsSettingViaScript = false;

		GetComponentInParent<FireHadouken>().trackTarget = null;
	}
}
