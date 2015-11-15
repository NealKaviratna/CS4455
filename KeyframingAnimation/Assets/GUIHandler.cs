using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIHandler : MonoBehaviour {

    public AudioSource source;
    public Slider volumeSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetVolume()
    {
        source.volume = volumeSlider.value;
    }
}
