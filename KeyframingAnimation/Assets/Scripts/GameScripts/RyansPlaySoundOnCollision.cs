using UnityEngine;
using System.Collections;

public class RyansPlaySoundOnCollision: MonoBehaviour {

	public AudioClip[] clips;
	public int numClips = 4; //TODO: just change this to the array size you dummy
	public float volume = 1.0f; //Apparently the third paramter in PlayClipAtPoint does jack shit woohoo

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != "pantspants")
//			Debug.Log ("Playing sound from RyansBoxSounds");
			AudioSource.PlayClipAtPoint(clips[Random.Range(0, numClips-1)], gameObject.transform.position, volume);
	}
}
