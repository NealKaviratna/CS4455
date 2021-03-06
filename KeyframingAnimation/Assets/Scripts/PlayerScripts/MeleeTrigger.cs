﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeTrigger : MonoBehaviour {

    List<GameObject> nearbyEnemies = new List<GameObject>();
	public AudioClip[] whoosh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Melee()
    {
		AudioSource.PlayClipAtPoint(whoosh[Random.Range(0, 2)], transform.position);
        Vector3 myPos = transform.position;
        if (nearbyEnemies.Count > 0)
        {
            for (int i = 0; i < nearbyEnemies.Count; i++)
            {
                if (nearbyEnemies[i] != null)
                {
                    Vector3 ePos = nearbyEnemies[i].transform.position;
                    Vector3 diff = ePos - myPos;
                    Debug.Log(Vector3.Dot(diff, transform.forward));
                    float dist = Vector3.Dot(diff, transform.forward);
                    if (dist <= 1.25f && dist > 0f)
                    {
                        nearbyEnemies[i].GetComponent<Enemy>().takeHit(20);
                    }
                }
            }
        }
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Enemy>() != null)
        {
            nearbyEnemies.Add(coll.gameObject);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.GetComponent<Enemy>() != null)
        {
            nearbyEnemies.Remove(coll.gameObject);
        }
    }
}
