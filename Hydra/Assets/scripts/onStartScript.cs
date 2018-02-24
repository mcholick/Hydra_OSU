using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onStartScript : MonoBehaviour {

    public GameObject unicorn;
    public GameObject horn;
    public GameObject milk;
    public GameObject booze;
    public GameObject player;

    // Use this for initialization
    void Start () {
        if (Game.current.player.unicorn == true && unicorn != null)
        {
            if (Game.current.player.horn == false && horn != null)
            {
                horn.transform.position = unicorn.transform.position;
            }
            GameObject.Destroy(unicorn);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
