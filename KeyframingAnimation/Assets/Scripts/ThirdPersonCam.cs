using UnityEngine;
using System.Collections;

public class ThirdPersonCam : MonoBehaviour
{

    public Transform target;
    Transform self;


    void Start()
    {
        self = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        self.position = target.position;
    }
}
