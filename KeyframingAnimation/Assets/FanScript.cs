using UnityEngine;
using System.Collections;

public class FanScript : MonoBehaviour {

    public GameObject blade1;
    public GameObject blade2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        blade1.transform.Rotate(0, 1000 * Time.deltaTime, 0);
        blade2.transform.Rotate(0, 1000 * Time.deltaTime, 0);
    }
}
