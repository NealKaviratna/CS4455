using UnityEngine;
using System.Collections;

public class XRayBehaviour : MonoBehaviour {

	private Renderer[] renderers;
	private float timer = 5.0f;

	// Use this for initialization
	void Start () {
		renderers = gameObject.GetComponentsInChildren<Renderer>();

		foreach (Renderer r in renderers) {
			r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			foreach (Renderer r in renderers) {
				r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 255);
			}
			Object.Destroy(this);
		}
	}
}
