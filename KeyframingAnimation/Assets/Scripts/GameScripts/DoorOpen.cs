//A quick and dirty door opener script.

using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour
{

    Vector3 startPosition;
    Vector3 endPosition;
    public float vectorOffset = 0; //Use this to tweek where the door should "stop"
    public float doorSpeed = 1.0f;
    public bool isBroken;
    bool triggered = false;
    public ParticleSystem sparks;
    public ParticleSystem smoke;

    void Start()
    {

        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y + vectorOffset, startPosition.z);
        if (sparks) sparks.enableEmission = false;
        if (smoke) smoke.enableEmission = false;

    }

    void Update()
    {
        if (triggered)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, doorSpeed*Time.deltaTime);
            if (isBroken)
            {
                if (sparks) sparks.enableEmission = true;
                if (smoke) smoke.enableEmission = true;
            }
        }
        else if (!triggered && !isBroken)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, doorSpeed*Time.deltaTime);
        }
    }

    public void SetTriggered()
    {
        this.triggered = !triggered;
    }
}
