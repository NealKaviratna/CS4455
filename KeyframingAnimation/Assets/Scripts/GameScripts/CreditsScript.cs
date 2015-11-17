using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + Vector3.up * Time.deltaTime * speed;
	}
}
