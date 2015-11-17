using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuCameraMovement : MonoBehaviour {

    public Transform currentMount;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speed);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speed);
	}

	public void DoNothing() {

	}

    public void SetMount(Transform newMount)
    {
        currentMount = newMount;
    }

	public void SetButtonFocus(Button focus)
	{
		EventSystem.current.SetSelectedGameObject (null);
		focus.Select ();
	}
}
