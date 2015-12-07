using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class win : MonoBehaviour {

	//public FadeScreen fs;
	public GameObject menu;
	public Button b;

	// Use this for initialization
	void Start () {
		menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Win() {
		menu.SetActive (true);
		EventSystem.current.SetSelectedGameObject (null);
		b.Select ();
	}

}
