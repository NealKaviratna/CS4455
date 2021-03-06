﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
//using UnityEditor;

public class PauseGame : MonoBehaviour {

    public GameObject menu;
    public FadeScreen fader;
	public Button focus;
    private bool enable = false;

	// Use this for initialization
	void Start () {
        menu.SetActive(enable);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            enable = !enable;
            menu.SetActive(enable);
            Pause();
        }
	}

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		EventSystem.current.SetSelectedGameObject (null);
		focus.Select ();
    }

    public void UnPause()
    {
        Debug.Log("Unpause");
        Time.timeScale = 1;
        enable = false;
        menu.SetActive(enable);
    }

    public void ReturnToMain()
    {
        UnPause();
        fader.SetStart(false);
        fader.SwitchScene(0);        
    }

    public void RestartLevel(int level)
    {
        Debug.Log("RESTART");
        UnPause();
        fader.SetStart(false);
        fader.SwitchScene(level);
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
