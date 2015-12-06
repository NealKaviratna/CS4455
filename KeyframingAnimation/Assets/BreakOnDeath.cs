using UnityEngine;
using System.Collections;

public class BreakOnDeath : MonoBehaviour {

    public Enemy bag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (bag.HP <= 0)
        {
            GetComponent<ConfigurableJoint>().breakForce = 0;
        }
	}
}
