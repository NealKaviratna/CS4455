﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScreen : MonoBehaviour {

	//public Texture2D fadeScreen;
	public float speed = 0.0f;
    public Image overlay;
    public AudioSource MyAudio;
	public bool fadeAudio = true;
    private bool startScene = true;
    private bool exitScene = false;
    private int level;

	//private float alphaFade = 1.0f;
	//private int fadeInOut = -1;
	//private int depth = -1000;


	// Use this for initialization
	void Start () {
        //GUITexture overlay = GetComponent<GUITexture>();
        //overlay.enabled = true;
	}
    /*
	void OnGUI () {
		alphaFade += fadeInOut * speed * Time.deltaTime;
		alphaFade = Mathf.Clamp01 (alphaFade);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alphaFade);
		GUI.depth = depth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeScreen);
	}

	public float StartFade(int inOut) {
		fadeInOut = inOut;
		return (speed);
	}

	void OnLevelWasLoaded() {
		StartFade (-1);
	}*/

    void Update()
    {
        if (startScene)
        {
            BeginScene();
        } else if (exitScene) {
            FadeOut();

            if (overlay.color.a >= 0.98f)
            {
                Application.LoadLevel(level);
            }
        }
    }

    void FadeIn()
    {
        overlay.color = Color.Lerp(overlay.color, Color.clear, speed * Time.deltaTime);
        if (fadeAudio) MyAudio.volume = Mathf.Lerp(MyAudio.volume, 1f, Time.deltaTime*speed);
    }

    void FadeOut()
    {
        overlay.color = Color.Lerp(overlay.color, Color.black, speed * Time.deltaTime);
        if (fadeAudio) MyAudio.volume = Mathf.Lerp(MyAudio.volume, 0f, Time.deltaTime * speed);
    }

    void BeginScene()
    {
        FadeIn();

        if (overlay.color.a <= 0.02f)
        {
            overlay.color = Color.clear;
            overlay.enabled = false;

            startScene = false;
        }
    }

    public void SetStart(bool b)
    {
        this.startScene = b;
    }

    public void SwitchScene(int nextLevel)
    {
        Debug.Log("switch");
        overlay.enabled = true;
        exitScene = true;
        level = nextLevel;
    }
}
