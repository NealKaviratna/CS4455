using UnityEngine;
using System.Collections;

public class win : MonoBehaviour {

	//public FadeScreen fs;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Win() {
		menu.SetActive (true);
	}

}
