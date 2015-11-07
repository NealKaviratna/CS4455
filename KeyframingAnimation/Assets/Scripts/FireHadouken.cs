using UnityEngine;
using System.Collections;

public class FireHadouken : MonoBehaviour {

    public GameObject hadoukenBall;
    public Transform firePos;


	// Use this for initialization
	void Start () {
        
	}
	
	void fireHadouken () {
        Debug.Log(firePos);
        GameObject hado = (GameObject)Instantiate(hadoukenBall, firePos.position, transform.rotation);
    }
}
