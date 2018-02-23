using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Game.current.player.door == true)
        {
            GameObject.Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (Game.current.player.horn == true && Game.current.player.heads == true && coll.gameObject.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
