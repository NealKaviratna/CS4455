using UnityEngine;
using System.Collections;

public class EnemyMeleeHelper : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void EnemyMelee()
    {
        EnemyMeleeTrigger e = GetComponentInChildren<EnemyMeleeTrigger>();
        Debug.Log(e);
        if (e != null)
        {
            Debug.Log("Success");
            e.EnemyMelee(player);
        }
    }
}
