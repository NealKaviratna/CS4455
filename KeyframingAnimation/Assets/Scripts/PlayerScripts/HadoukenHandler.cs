using UnityEngine;
using System.Collections;

public class HadoukenHandler : MonoBehaviour {

    public float speed;
    private Vector3 direction;
    //private Transform myTrans;
    private float time = 2f;

    // Use this for initialization
    void Start () {
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z +1);
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0) Destroy(this.gameObject);
        transform.position = transform.position + transform.forward*speed * Time.deltaTime * 60;
	}

    void OnCollisionEnter(Collision coll)
    {
        GameObject other = coll.gameObject;
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeHit(50f);
        }
        Destroy(this.gameObject);
    }
}
