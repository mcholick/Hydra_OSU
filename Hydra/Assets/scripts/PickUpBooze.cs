using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBooze : MonoBehaviour {

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Game.current.boozeOnGround = false;
            Game.current.player.booze = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
