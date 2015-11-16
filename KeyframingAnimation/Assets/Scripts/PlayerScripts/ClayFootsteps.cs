using UnityEngine;
using System.Collections;

public class ClayFootsteps : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioClip death;
    private SmoothAnimScript smoothAnim;
    private CharacterController charController;
    private LookAtMouse lookAtMouse;
    private bool isMoving = false;
    private bool crouched = false;
    private int soundOffset = 0;
    private float crouchDelay = 0.7f;
    private float crouchTime = 0.0f;
    private bool workaround;
    public Transform respawn;

    // Use this for initialization
    void Start()
    {
        charController = GetComponent<CharacterController>();
        workaround = true;
        smoothAnim = GetComponent<SmoothAnimScript>();
        lookAtMouse = GetComponent<LookAtMouse>();
        if (!crouched)
        {
            InvokeRepeating("Moving", 0.5f, 0.3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = smoothAnim.GetMoving();
        crouched = smoothAnim.GetCrouched();
        Vector3 pos = transform.position + (new Vector3(0, 0.2f, 0));
        Ray downRay = new Ray(pos, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.collider.tag == "Grass")
            {
                soundOffset = 4;
            }
            else if (hit.collider.tag == "RegFloor")
            {
                soundOffset = 0;
            }
            else if (hit.collider.tag == "Gravel")
            {
                soundOffset = 8;
            }
        }
        crouchTime += Time.deltaTime;
        //This is here because of a Unity-crashing bug related to deactivating animators
        smoothAnim.animator.enabled = workaround;

        if (gameObject.transform.position.y < -5)
        {
            gameObject.transform.position = respawn.position;
        }
    }


    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            AudioSource.PlayClipAtPoint(death, gameObject.transform.position);
            charController.enabled = false;
            lookAtMouse.enabled = false;
            workaround = false;
        }
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
            }
            else
            {
                AudioSource.PlayClipAtPoint(clips[Random.Range(soundOffset, soundOffset + 4)], gameObject.transform.position);
            }

        }
    }
}
