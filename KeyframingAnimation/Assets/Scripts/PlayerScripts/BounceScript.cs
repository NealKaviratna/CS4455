using UnityEngine;
using System.Collections;

public class BounceScript : MonoBehaviour
{
    public float jumpSpeed;
    public float gravity;
    private bool bounce;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        bounce = false;
    }
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (bounce)
        {
            moveDirection = Vector3.zero;
            moveDirection.y = jumpSpeed;
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
            bounce = true;
        }
    }
}