using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class WinGUIHandler : MonoBehaviour {

    public Text score;
    public Text clear_time;
    public Text killed;
    public ScoreManager sm;
    public GameObject menu;
	public FadeScreen fs;
	public Button focused_b;

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
		EventSystem.current.SetSelectedGameObject (null);
		focused_b.Select ();
        score.text = "Score: " + sm.getScore();
        killed.text = "Enemies Killed: " + sm.getKilled();
    }

	public void NextLevel(int level) {
		menu.SetActive (false);
		fs.SwitchScene (level);
	}
}
