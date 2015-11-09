using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public PlayerHealth h;
	public GameObject text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if (h.health < 0f)
        {
            this.GetComponent<Image>().enabled = true;
			this.text.SetActive(true);
        }
	}
}
