using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveChest : MonoBehaviour {

    public GameObject openedChest1;
    private bool inArea = false;

    void Start()
    {
        if (Game.current.caveChestLooted == true)
        {
            openedChest1.transform.position = new Vector3((float)13.808, (float)3.859, 0);
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = false;
        }
    }

    void Update()
    {
        if (inArea && Input.GetKeyDown("space"))
        {
            Game.current.player.gold = Game.current.player.gold + 10000000;
            Game.current.caveChestLooted = true;
            openedChest1.transform.position = new Vector3((float)13.808, (float)3.859, 0);
            GameObject.Destroy(this.gameObject);
        }
    }

}
