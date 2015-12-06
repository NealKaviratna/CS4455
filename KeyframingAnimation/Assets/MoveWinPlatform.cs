using UnityEngine;
using System.Collections;

public class MoveWinPlatform : MonoBehaviour {

    public Transform target_pos;
    public float speed;

	// Use this for initialization
	void Start () {
        //target_pos = new Vector3(0f, -2.25f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target_pos.position, speed * Time.deltaTime);
	}
}
