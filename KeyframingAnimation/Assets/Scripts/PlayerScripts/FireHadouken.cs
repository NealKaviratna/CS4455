using UnityEngine;
using System.Collections;

public class FireHadouken : MonoBehaviour {

    public GameObject hadoukenBall;
    public Transform firePos;

	public Transform trackTarget;
	public GameObject hadoukenRef;

	public PlayerHealth ph;
	public AudioClip sound_play;

	void Start() {
		ph = GetComponent<PlayerHealth> ();
	}

	void Update () {
		if (hadoukenRef != null && trackTarget != null) {
			hadoukenRef.transform.LookAt(trackTarget.position + Vector3.up);
		}
	}
	
	void fireHadouken () {
		ph.UseEnergy (20f);
		AudioSource.PlayClipAtPoint (sound_play, transform.position);
		hadoukenRef = Instantiate(hadoukenBall, firePos.position + this.transform.forward*2 , transform.rotation) as GameObject;
		hadoukenRef.GetComponent<HadoukenHandler>().player = this.gameObject;
    }
}
