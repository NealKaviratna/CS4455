using UnityEngine;
using System.Collections;

public class RobertFootsteps : MonoBehaviour {

    public AudioClip[] clips;
    private SmoothAnimScript smoothAnim;
    private CharacterController charCont;
    private bool isMoving = false;

	// Use this for initialization
	void Start () {
        smoothAnim = GetComponent<SmoothAnimScript>();
        charCont = GetComponent<CharacterController>();
        InvokeRepeating("Moving", 0.5f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
        isMoving = smoothAnim.GetMoving();
	}

    void Moving()
    {
        if (isMoving)
        {
            AudioSource.PlayClipAtPoint(clips[Random.Range(0, clips.Length)], gameObject.transform.position);
        }
    }
}
