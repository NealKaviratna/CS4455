using UnityEngine;
using System.Collections;

public class FloatScript : MonoBehaviour {

    public CharacterController playerController;
    public Rigidbody playerRigidBody;
    private float movementSpeed;
    private bool floating;

	// Use this for initialization
	void Start () {
        movementSpeed = 0.1f;
        floating = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (floating && transform.position.y < 5)
        {
            transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
            movementSpeed += .04f;
        }

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Untagged"))
        {
            floating = true;
        }

    }
    /*
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            movementSpeed = 0;
        }
    }*/

}
