using UnityEngine;
using System.Collections;

public class EnergyPackScript : MonoBehaviour {
	
	public float rotationRate = 40f;
	private bool taken;
	SmoothAnimScript smooth;

	public GameObject player;
	public PlayerHealth playerHealth;
	public int health = 1;
	
	
	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player");
		//playerHealth = player.GetComponent<PlayerHealth> ();
		smooth = player.GetComponent<SmoothAnimScript> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			if (!taken)
			{
				taken = true;
				giveEnergy();
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
	
	void giveEnergy () 
	{
		smooth.energy=smooth.energy+50;
		Destroy(gameObject);
	}
}
