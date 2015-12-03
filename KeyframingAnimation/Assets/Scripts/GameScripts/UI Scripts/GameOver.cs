using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public PlayerHealth h;
    public MeleeInput inputControl;
    public LookAtMouse mouseLook;
    public FadeScreen fader;
    private Canvas menu;

    private bool isDead;

	// Use this for initialization
	void Start () {
        menu = GetComponent<Canvas>();
        if (menu) menu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (h.transform.position.z > 117.5)
        {
            /*this.GetComponent<Image>().enabled = true;
            this.text2.SetActive(true);*/
            if (menu)
            {
                this.menu.enabled = true;
            }
        }

        if (h.health <= 0f && !isDead)
        {
            isDead = true;
            if (inputControl) inputControl.enabled = false;
            mouseLook.enabled = false;
            if (menu) this.menu.enabled = true;
        }


        if (h.transform.position.y < -20)
        {
            /*this.GetComponent<Image>().enabled = true;
			this.text.SetActive(true);*/
            if (menu && !isDead)
            {
                isDead = true;
                this.menu.enabled = true;
                Time.timeScale = 0;
            }
        }
	}

    public void RestartLevel(int level)
    {
        fader.SetStart(false);
        fader.SwitchScene(level);
    }
}
