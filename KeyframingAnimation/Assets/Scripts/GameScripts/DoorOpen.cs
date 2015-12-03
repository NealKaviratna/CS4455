//A quick and dirty door opener script.

using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour
{

    Vector3 startPosition;
    Vector3 endPosition;
    public float vectorOffset = 0; //Use this to tweek where the door should "stop"
    public float doorSpeed = 1.0f;
    bool triggered = false;

    void Start()
    {

        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y + vectorOffset, startPosition.z);

    }

    void Update()
    {
        if (triggered)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, doorSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, doorSpeed);
        }
    }

    public void SetTriggered()
    {
        this.triggered = !triggered;
    }
}
