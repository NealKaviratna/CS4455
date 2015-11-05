using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public bool isActive;
	public float distance;

	public float proxMultiplier;
	public Transform player;

	public float totalTimer;
	public bool detonate;

	public GameObject explosion;
	
	private LookAtMouse lookAtMouse;

	// Use this for initialization
	void Start () {
		isActive = false;
		distance = 1000000;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		totalTimer = 5000;
		detonate = false;
		
		lookAtMouse = player.gameObject.GetComponent<LookAtMouse>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			distance = Vector3.Distance(player.position, this.transform.position);
			Debug.Log(distance);
			proxMultiplier = (1000 / Mathf.Log(distance));

			totalTimer -= Time.deltaTime * proxMultiplier;
			this.gameObject.GetComponent<AudioSource>().pitch = Mathf.Clamp(5 - distance, 1, 10);
		}

		if (totalTimer < 0.0f || detonate) {
			player.gameObject.GetComponent<Animator>().enabled = false;
			player.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10,this.transform.position, 10);
			lookAtMouse.enabled = !lookAtMouse.enabled;
			Instantiate(explosion, this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player") {
			this.gameObject.GetComponent<AudioSource>().Play();
			isActive = true;
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.tag == "Player") {
			this.gameObject.GetComponent<AudioSource>().Stop();
			this.gameObject.GetComponent<AudioSource>().pitch = 1;
			this.totalTimer = 5000;
			isActive = false;
		}
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.collider.GetComponentInParent<LookAtMouse>()) detonate = true;
		else if(coll.collider.GetComponentInChildren<SuicideBot>()) {
			Transform tr = coll.collider.gameObject.transform;
			this.transform.position = tr.position;
			this.transform.rotation = tr.transform.rotation;
			this.transform.parent = tr;
		}
	}
}
