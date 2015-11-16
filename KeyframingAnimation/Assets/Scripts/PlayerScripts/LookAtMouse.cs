//Borrowed from http://wiki.unity3d.com/index.php?title=LookAtMouse

using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour
{
	
	// speed is the rate at which the object will rotate
	public float speed;

	public bool useGamepad = false;

	public GameObject pointer;

	private float lastX;
	private float lastY;

	void Start()
	{
		if (Input.GetJoystickNames().Length > 0) useGamepad = true;
	}
	
	void FixedUpdate () 
	{
		if (!useGamepad)
		{
			// Generate a plane that intersects the transform's position with an upwards normal.
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			
			// Generate a ray from the cursor position
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			// Determine the point where the cursor ray intersects the plane.
			// This will be the point that the object must look towards to be looking at the mouse.
			// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
			//   then find the point along that ray that meets that distance.  This will be the point
			//   to look at.
			float hitdist = 0.0f;
			// If the ray is parallel to the plane, Raycast will return false.
			if (playerPlane.Raycast (ray, out hitdist)) 
			{
				// Get the point along the ray that hits the calculated distance.
				Vector3 targetPoint = ray.GetPoint(hitdist);
				
				// Determine the target rotation.  This is the rotation if the transform looks at the target point.
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				
				// Smoothly rotate towards the target point.
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
			}
		}
		else
		{
			pointer.transform.position = this.transform.position;
			float x = Input.GetAxis("RightJoystickX");
			float y = Input.GetAxis("RightJoystickY");

			if (x == 0 && y == 0)
			{ 
				x = lastX;
				y = lastY;
			}
			lastX = x;
			lastY = y;

			pointer.transform.eulerAngles = new Vector3(pointer.transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, pointer.transform.eulerAngles.z);
			Vector3 targetPoint = pointer.transform.position + pointer.transform.forward;

			// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			
			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
		}
	}
}