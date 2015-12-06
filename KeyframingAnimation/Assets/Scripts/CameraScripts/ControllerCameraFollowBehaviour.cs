using UnityEngine;
using System.Collections;

public class ControllerCameraFollowBehaviour : MonoBehaviour {

    public float smoothing = 2;

    public Transform followTarget;
	public Transform lookTarget;

	private Transform originalLookTarget;

    void Start()
    {
		originalLookTarget = lookTarget;
	}

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position, Time.deltaTime * 10);

        transform.LookAt(lookTarget);
    }

	public void ResetLook() {
		lookTarget = originalLookTarget;
	}
}
