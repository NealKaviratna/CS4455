using UnityEngine;
using System.Collections;

public class FloatReset : MonoBehaviour {

    public GameObject lift;
    public Transform liftRespawn;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            lift.transform.position = new Vector3(lift.transform.position.x, other.gameObject.transform.position.y - 1.3f, lift.transform.position.z);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            lift.transform.position = liftRespawn.position;
    }
}
