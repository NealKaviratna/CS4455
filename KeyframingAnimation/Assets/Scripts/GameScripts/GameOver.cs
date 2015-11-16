using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public PlayerHealth h;
	public GameObject text;
    public GameObject text2;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (h.transform.position.z > 117.5)
        {
            this.GetComponent<Image>().enabled = true;
            this.text2.SetActive(true);
        }


        if (h.health < 0f || h.transform.position.y < -50)
        {
            this.GetComponent<Image>().enabled = true;
			this.text.SetActive(true);
        }
	}
}
