﻿using UnityEngine;
using System.Collections;

public class EnemyFireHadouken : MonoBehaviour
{

    public GameObject hadoukenBall;
    public Transform firePos;


    // Use this for initialization
    void Start()
    {

    }

    void Hadouken()
    {
        //Debug.Log(firePos);
        Instantiate(hadoukenBall, firePos.position + transform.forward, transform.rotation);
    }
}