using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

    public float speed;
    public FadeScreen fade;
    private bool exit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.up * Time.deltaTime * speed;
        if (transform.position.y > 15.5f && !exit)
        {
            exit = true;
            fade.SwitchScene(0);
        }
	}
}
