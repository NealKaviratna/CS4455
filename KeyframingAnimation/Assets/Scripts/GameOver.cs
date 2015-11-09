using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public PlayerHealth h;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (h.health < 0f)
        {
            gameObject.SetActive(true);
        }
	}
}
