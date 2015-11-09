using UnityEngine;
using System.Collections;

public class HealthPackBehavior : MonoBehaviour {

	public float rotationRate = 40f;
	private bool taken;

	public GameObject player;
	public PlayerHealth playerHealth;
	public int health = 1;


	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player");
		//playerHealth = player.GetComponent<PlayerHealth> ();

	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
            if (!taken)
            {
                taken = true;
                HealthTaken();
            }
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		
	}
	

	void Update () 
	{
		transform.RotateAround (transform.position, Vector3.up, rotationRate * Time.deltaTime);
	}

	void HealthTaken () 
	{
		playerHealth.getHealth (20);
		Destroy(gameObject);
	}
}
