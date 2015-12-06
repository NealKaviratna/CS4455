using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

    public WinGUIHandler wgh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            wgh.SignalWin();
        }
    }
}
