using UnityEngine;
using System.Collections;

public class RyansDoorSoundController: MonoBehaviour {
	
	public AudioClip[] clips;
	public int numClips = 4; //TODO: just change this to the array size you dummy
	private bool playSound = false;
//	private bool resetter = true;
	private float currRot; //current rotation
	private float oldRot;
	private float rotDelta;
	private bool playable = true;
	
	// Use this for initialization
	void Start () {
		oldRot = gameObject.transform.localEulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		currRot = gameObject.transform.localEulerAngles.y;
		rotDelta = Mathf.Abs (oldRot - currRot);
//		Debug.Log (currRot + " " + playable);
		Debug.Log ("Curr " + currRot + " old " + oldRot + " delta " + rotDelta);
		if ((currRot > 90.0f  && currRot < 95.0f ) ||
			(currRot > 175.0f && currRot < 185.0f) ||
			(currRot > 265.0f && currRot < 275.0f) ||
			(currRot > 355.0f && currRot < 360.0f) ||
		    (currRot > 0.0f   && currRot < 5.0f  ))
			playSound = true;
		else
			playable = true;

		if (playSound == true && playable == true && rotDelta > 2.0f) {
			AudioSource.PlayClipAtPoint (clips [Random.Range (0, numClips - 1)], gameObject.transform.position);
			playSound = false;
			playable = false;
		}
		oldRot = currRot;
	}
}
