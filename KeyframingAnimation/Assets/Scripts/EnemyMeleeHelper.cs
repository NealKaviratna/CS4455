using UnityEngine;
using System.Collections;

public class EnemyMeleeHelper : MonoBehaviour {

    GameObject player;
    Enemy eScript;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        eScript = GetComponent<Enemy>();
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
            e.EnemyMelee(player, eScript.isAlive);
        }
    }
}
