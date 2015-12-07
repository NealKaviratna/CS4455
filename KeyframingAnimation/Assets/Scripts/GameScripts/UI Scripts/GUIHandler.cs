using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIHandler : MonoBehaviour {

    public AudioSource source;
    public Slider volumeSlider;

	// Use this for initialization
	void Start () {
		source.volume = .05f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetVolume()
    {
        source.volume = volumeSlider.value;
    }
}
