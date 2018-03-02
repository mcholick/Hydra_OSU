using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazechest : MonoBehaviour {


    public GameObject openedChest2;
    private bool inArea = false;

    void Start()
    {
        if (Game.current.mazeChestLooted == true)
        {
            openedChest2.transform.position = new Vector3((float)-26.465, (float)1.081, 0);
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
        if (inArea && Input.GetKeyDown("space") && Game.current.mazeChestLooted != true)
        {
            Game.current.player.gold = Game.current.player.gold + 10000000;
            Game.current.mazeChestLooted = true;
            openedChest2.transform.position = new Vector3((float)-26.465, (float)1.081, 0);
            GameObject.Destroy(this.gameObject);
        }
    }

}
