using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMeleeTrigger : MonoBehaviour
{

    //GameObject player;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyMelee(GameObject player, bool isAlive)
    {
        if (player != null && isAlive)
        {
            Vector3 myPos = transform.position;
            Vector3 pPos = player.transform.position;
            Vector3 diff = pPos - myPos;
            Debug.Log(Vector3.Dot(diff, transform.forward));
            float dist = Vector3.Dot(diff, transform.forward);
            if (dist <= 1.25f && dist > 0f)
            {
                player.GetComponent<PlayerHealth>().takeHit(20);
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Collider>().tag == "Player")
        {
            //player = coll.gameObject;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.GetComponent<Collider>().tag == "Enemy")
        {
            //player = null;
        }
    }
}
