using UnityEngine;
using System.Collections;

public class Slidingsfx : MonoBehaviour {

	public Animator anim;
	public AudioSource audio;
	public Rigidbody player;

	private bool onIce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		audio.volume = Mathf.Lerp(0.0f,0.4f, player.velocity.magnitude/16.0f);
		if(!anim.enabled && player.velocity.magnitude > 1 && !this.audio.isPlaying) {
			this.audio.PlayDelayed(.2f);
		}

		if(player.velocity.magnitude < 0.1) {
			this.audio.Stop();
		}
	}
}
