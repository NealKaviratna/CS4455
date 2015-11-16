using UnityEngine;
using System.Collections;

public class LoadLevelHelper: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchLevel(int level)
    {
        Application.LoadLevel(level);
    }

}
