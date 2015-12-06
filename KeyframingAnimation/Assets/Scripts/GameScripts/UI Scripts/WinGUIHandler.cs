using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinGUIHandler : MonoBehaviour {

    public Text score;
    public Text clear_time;
    public Text killed;
    public ScoreManager sm;
    public GameObject menu;

	// Use this for initialization
	void Start () {
        menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SignalWin()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        score.text = "Score: " + sm.getScore();
        killed.text = "Enemies Killed: " + sm.getKilled();
    }
}
