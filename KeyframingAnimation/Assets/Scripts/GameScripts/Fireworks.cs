using UnityEngine;
using System.Collections;

public class Fireworks : MonoBehaviour {

    public ParticleSystem particles;

	// Use this for initialization
	void Start () {
        particles.Stop();
	}
	
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            particles.Play();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
