using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEditor;

public class PauseGame : MonoBehaviour {

    private Canvas menu;
    public FadeScreen fader;

	// Use this for initialization
	void Start () {
        menu = GetComponent<Canvas>();
        menu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = !menu.enabled;
            Pause();
        }
	}

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        menu.enabled = false;
    }

    public void ReturnToMain()
    {
        UnPause();
        fader.SetStart(false);
        fader.SwitchScene(0);        
    }

    public void ExitGame()
    {
        /*#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif*/
        Application.Quit();
    }
}
