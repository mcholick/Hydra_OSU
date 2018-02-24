using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveChest : MonoBehaviour {

    public GameObject openedChest1;

    void Start()
    {
        if (Game.current.caveChestLooted == true)
        {
            openedChest1.transform.position = new Vector3((float)13.808, (float)3.859, 0);
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && Game.current.chestUnlocked==true && Game.current.caveChestLooted==false)
        {
            Game.current.player.gold = Game.current.player.gold + 10000000;
            Game.current.caveChestLooted = true;
            openedChest1.transform.position = new Vector3((float)13.808, (float)3.859, 0);
            GameObject.Destroy(this.gameObject);
        }
    }

}
