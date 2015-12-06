using UnityEngine;
using System.Collections;

public class HadoukenHandler : MonoBehaviour {

    public float speed;
    private Vector3 direction;
    //private Transform myTrans;
    private float time = 2f;
	public GameObject player;
	private Transform player_loc;

    // Use this for initialization
    void Start () {
		player_loc = player.transform;
		//Transform player = GameObject.FindGameObjectWithTag("Player").transform;
		//myTrans = GetComponent<Transform>();
		transform.position = player_loc.position + Vector3.up + player_loc.forward;
		direction = player_loc.forward*speed;
		Debug.Log(direction);
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
