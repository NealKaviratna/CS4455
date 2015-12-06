using UnityEngine;
using System.Collections;

public class ZTargetable : MonoBehaviour {
	private ControllerCameraTargetBehavoiur ZTargetReference;

	// Use this for initialization
	void Start () {
		ZTargetReference = Camera.main.GetComponent<ControllerCameraFollowBehaviour>().followTarget.GetComponent<ControllerCameraTargetBehavoiur>();
	}

	void OnBecameVisible() {
		this.ZTargetReference.PotentialZTargets.Add(transform.parent.gameObject);
	}
	
	void OnBecameInvisible() {
		this.ZTargetReference.PotentialZTargets.Remove(transform.parent.gameObject);
	}
}
