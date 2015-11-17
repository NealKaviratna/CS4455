using UnityEngine;
using System.Collections;

public class FadeScreen : MonoBehaviour {

	public Texture2D fadeScreen;
	public float speed = 0.0f;

	private float alphaFade = 1.0f;
	private int fadeInOut = -1;
	private int depth = -1000;


	// Use this for initialization
	void Start () {
	
	}

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
	}
}
