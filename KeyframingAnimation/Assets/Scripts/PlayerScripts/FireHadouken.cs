using UnityEngine;
using System.Collections;

public class FireHadouken : MonoBehaviour {

    public GameObject hadoukenBall;
    public Transform firePos;

	public Transform trackTarget;
	public GameObject hadoukenRef;

	void Start() {

	}

	void Update () {
		Debug.Log(hadoukenRef);
		Debug.Log(trackTarget);
		if (hadoukenRef != null && trackTarget != null) {
			hadoukenRef.transform.LookAt(trackTarget.position + Vector3.up);
		}
	}
	
	void fireHadouken () {
		hadoukenRef = Instantiate(hadoukenBall, firePos.position + this.transform.forward*2 , transform.rotation) as GameObject;
		hadoukenRef.GetComponent<HadoukenHandler>().player = this.gameObject;
    }
}
