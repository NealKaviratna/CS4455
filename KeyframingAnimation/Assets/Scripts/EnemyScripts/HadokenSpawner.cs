using UnityEngine;
using System.Collections;

/**
 * @Author: Team Wombo Combo
 *          -Neal Kaviratna
 *          -Robert Borowicz
 *          -Ryan Mendes
 *          -Clay Anderson
 *          -Rich Li
 **/
public class HadokenSpawner : MonoBehaviour {
	
	public GameObject enemy;
	public Transform spawnPoint;
	public Transform heroLoc;
	public Animator heroAnim;
	public Transform shooterLoc;
	// Use this for initialization
	void Start () {
		//Spawn ();
	}
	
	// Update is called once per frame
	public void Spawn() {
		GameObject hado = (GameObject)Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		ProjectileScript hados = hado.GetComponent<ProjectileScript> ();
		hados.heroLoc = heroLoc;
		hados.heroAnim=heroAnim;
		hados.shooterLoc=shooterLoc;
	}
}
