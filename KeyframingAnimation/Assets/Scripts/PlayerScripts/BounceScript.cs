using UnityEngine;
using System.Collections;

public class BounceScript : MonoBehaviour
{
    public AudioClip clip;
    public float jumpSpeed;
    public float gravity;
	public float lateral;
    private bool bounce;
    private Vector3 moveDirection = Vector3.zero;
	private Transform pad;

    void Start()
    {
        bounce = false;
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (bounce)
        {
			moveDirection = pad.up;
			moveDirection.x *= lateral;
			moveDirection.z *= lateral;
            moveDirection.y = jumpSpeed*moveDirection.y;
            bounce = false;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        if (moveDirection.y <= 0)
            moveDirection = Vector3.zero;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        moveDirection = Vector3.zero;

        if (collision.gameObject.CompareTag("Bounce"))
        {
			Debug.Log ("thing");
			pad = collision.gameObject.transform;
            //AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            bounce = true;
        }
    }
}