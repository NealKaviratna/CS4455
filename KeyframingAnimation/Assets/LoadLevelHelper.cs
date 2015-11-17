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
		float fade = GameObject.Find ("Camera").GetComponent<FadeScreen> ().StartFade (1);
		//yield return new WaitForSeconds (fade);
        Application.LoadLevel(level);
    }

}
