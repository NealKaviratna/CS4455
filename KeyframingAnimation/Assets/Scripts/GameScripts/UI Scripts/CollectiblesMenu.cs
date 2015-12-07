using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectiblesMenu : MonoBehaviour {

    public Sprite blacked_out;
    public Sprite collected;
    public int sprite_number;

	// Use this for initialization
	void Start () {
        Sprite use_sprite = blacked_out;
        if (CollectiblesStatic.collectibles[sprite_number])
        {
            use_sprite = collected;
        }
        GetComponent<Image>().sprite = use_sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
