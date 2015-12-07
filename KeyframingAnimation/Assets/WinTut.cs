using UnityEngine;
using System.Collections;

public class WinTut : MonoBehaviour {

	public win w;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player")
		{
			if (w) w.Win ();
		}
	}
}
