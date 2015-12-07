using UnityEngine;
using System.Collections;

public class DoorButtonScript : MonoBehaviour {

    private bool inRange = false;
    private bool open = false;
    //public SmoothAnimScript inputControl;
    public DoorOpen door;
	public AudioClip button_sound;
	public AudioClip broken_sound;
	private AudioSource a_source;
    private Light buttonLight;

    private Color RED;
    private Color GREEN;

	// Use this for initialization
	void Start () {
		a_source = GetComponent<AudioSource> ();
        buttonLight = GetComponent<Light>();
        RED = new Color(255, 0, 0);
        GREEN = new Color(0, 255, 0);
    }
	
	// Update is called once per frame
	void Update () {
	    /*if (inputControl && inputControl.enabled)
        {
            inputControl.SetDoorNearby(inRange);
        }*/
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
				if (!door.isBroken){
					a_source.PlayOneShot(button_sound, .5f);
				}
				else {
					a_source.PlayOneShot(broken_sound, .7f);
				}
                open = !open;
                if (!door.isBroken) buttonLight.color = open ? GREEN : RED;
                door.SetTriggered();
            }
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
