using UnityEngine;
using System.Collections;

public class CollectibleGameHandler : MonoBehaviour {

    public float rotationRate = 40f;
    private bool taken;
    public int collectible_number;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationRate * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!taken)
            {
                taken = true;
                CollectItem();
            }
        }
    }

    void CollectItem()
    {
        CollectiblesStatic.collectibles[collectible_number] = true;
        Destroy(gameObject);
    }
}

