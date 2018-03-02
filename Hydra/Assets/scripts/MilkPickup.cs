using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPickup : MonoBehaviour {

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Game.current.milkOnGround = false;
            Game.current.player.milk = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
