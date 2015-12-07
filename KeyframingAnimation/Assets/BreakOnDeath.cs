using UnityEngine;
using System.Collections;

public class BreakOnDeath : MonoBehaviour {

    public Enemy bag;
	public DoorOpen door;
	public bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (bag.HP <= 0 && !dead)
        {
			if (GetComponent<ConfigurableJoint>() != null)
            	GetComponent<ConfigurableJoint>().breakForce = 0;
			door.SetTriggered ();
			dead = true;
        }
	}
}
