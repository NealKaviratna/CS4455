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

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player);
		agent.SetDestination(player.position);
	}
}
