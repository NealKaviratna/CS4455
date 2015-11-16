using UnityEngine;
using System.Collections;

/** Lava Kill
 * @Author: Team Wombo Combo
 *          -Robert Borowicz
 **/

public class LavaKillScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position + (new Vector3(0, 0.2f, 0));
        Ray downRay = new Ray(pos, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.collider.tag == "Lava")
            {
                anim.enabled = false;
                GetComponent<LookAtMouse>().enabled = false;
                GetComponent<RobertFootsteps>().SetUse(false);
            }
        }
    }
}
