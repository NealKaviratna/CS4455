using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialTextChanger : MonoBehaviour {

	public string tutorialText;
	public Text hudElement;
	private bool activated;

	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (!activated && other.gameObject.CompareTag("Player")) {
			activated = true;
			hudElement.text = tutorialText;
		}
	}
}
