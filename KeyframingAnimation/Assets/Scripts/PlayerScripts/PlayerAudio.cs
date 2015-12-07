using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

	private AudioSource a_source;

	// Use this for initialization
	void Start () {
		a_source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySoundClip(AudioClip clip) {
		a_source.PlayOneShot (clip, 1f);
	}
}
