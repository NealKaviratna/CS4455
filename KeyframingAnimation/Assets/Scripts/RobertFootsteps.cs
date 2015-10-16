using UnityEngine;
using System.Collections;

public class RobertFootsteps : MonoBehaviour {

    public AudioClip[] clips;
    private SmoothAnimScript smoothAnim;
    private CharacterController charCont;
    private bool isMoving = false;
    private int soundOffset = 0;

	// Use this for initialization
	void Start () {
        smoothAnim = GetComponent<SmoothAnimScript>();
        charCont = GetComponent<CharacterController>();
        InvokeRepeating("Moving", 0.5f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
        isMoving = smoothAnim.GetMoving();
        Vector3 pos = transform.position + (new Vector3(0, 1, 0));
        Ray footstepRay = new Ray(pos, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(footstepRay, out hit)){
            if(hit.collider.tag == "Water"){
                soundOffset = 4;
            } else if (hit.collider.tag == "Volcano")
            {
                soundOffset = 0;
            } else if (hit.collider.tag == "Sand")
            {
                soundOffset = 8;
            }
        }
    }


    void Moving()
    {
        if (isMoving)
        {
            AudioSource.PlayClipAtPoint(clips[Random.Range(soundOffset, soundOffset+4)], gameObject.transform.position);
        }
    }
}
