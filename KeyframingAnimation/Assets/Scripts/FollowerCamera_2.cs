using UnityEngine;
using System.Collections;

public class FollowerCamera_2 : MonoBehaviour {

    public GameObject target;
    private float dist_back = 1f;
    private float dist_up = 1f;
    public float smoothing = 2;
    Vector3 followTarget;

    void Start()
    {}

    void LateUpdate()
    {
        followTarget = target.transform.position + Vector3.up * dist_up - target.transform.forward * dist_back;
        transform.position = Vector3.Lerp(transform.position, followTarget, Time.deltaTime * smoothing);
        transform.LookAt(target.transform);
    }
}
