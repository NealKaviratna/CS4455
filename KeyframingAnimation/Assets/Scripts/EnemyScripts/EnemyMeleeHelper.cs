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
        if (e != null)
        {
            Debug.Log(eScript.IsAlive);
            e.EnemyMelee(player, eScript.IsAlive);
        }
    }
}
