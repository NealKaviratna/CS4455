using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnPoints;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 3f, 3f);
	}
	
	// Update is called once per frame
	void Spawn() {
		int index = Random.Range(0,2);
		Instantiate(enemy, spawnPoints[index].position, spawnPoints[index].rotation);
	}
}
