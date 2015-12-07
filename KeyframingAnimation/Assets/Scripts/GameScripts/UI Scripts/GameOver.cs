using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour {

    public PlayerHealth h;
    public MeleeInput inputControl;
    public LookAtMouse mouseLook;
    public FadeScreen fader;
    public GameObject menu;
	public PauseGame pause;
	public Button focus;

    private bool isDead;

	// Use this for initialization
	void Start () {
        //menu = GetComponent<Canvas>();
        menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (h.health <= 0f && !isDead)
        {
            isDead = true;
            if (inputControl) inputControl.enabled = false;
            if (mouseLook) mouseLook.enabled = false;
            if (menu) menu.SetActive(true);
			EventSystem.current.SetSelectedGameObject (null);
			if (focus) focus.Select ();
			if (pause) pause.gameObject.SetActive(false);
        }


        if (h.transform.position.y < -20)
        {
            /*this.GetComponent<Image>().enabled = true;
			this.text.SetActive(true);*/
            if (menu && !isDead)
            {
                isDead = true;
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
	}

	public void ReturnToMain() {
		menu.SetActive (false);
		pause.ReturnToMain ();
	}

    public void RestartLevel(int level)
    {
		menu.SetActive (false);
		pause.RestartLevel (level);
        //fader.SetStart(false);
        //fader.SwitchScene(level);
    }
}
