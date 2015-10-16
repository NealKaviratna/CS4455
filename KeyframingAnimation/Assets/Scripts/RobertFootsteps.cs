using UnityEngine;
using System.Collections;

public class RobertFootsteps : MonoBehaviour {

    public AudioClip[] clips;
    private SmoothAnimScript smoothAnim;
    private bool isMoving = false;
    private bool crouched = false;
    private int soundOffset = 0;
    private float crouchDelay = 0.7f;
    private float crouchTime = 0.0f;

	// Use this for initialization
	void Start () {
        smoothAnim = GetComponent<SmoothAnimScript>();
        if (!crouched)
        {
            InvokeRepeating("Moving", 0.5f, 0.3f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        isMoving = smoothAnim.GetMoving();
        crouched = smoothAnim.GetCrouched();
        Vector3 pos = transform.position + (new Vector3(0, 0.2f, 0));
        Ray downRay = new Ray(pos, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(downRay, out hit)){
            Debug.Log(hit.collider.tag);
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
        crouchTime += Time.deltaTime;
    }


    void Moving()
    {
        if (isMoving)
        {
            if (crouched)
            {
                if (crouchTime > crouchDelay)
                {
                    AudioSource.PlayClipAtPoint(clips[Random.Range(soundOffset, soundOffset + 4)], gameObject.transform.position);
                    crouchTime = 0.0f;
                }
            }else
            {
                AudioSource.PlayClipAtPoint(clips[Random.Range(soundOffset, soundOffset + 4)], gameObject.transform.position);
            }

        }
    }
}
