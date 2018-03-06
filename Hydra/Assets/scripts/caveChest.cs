using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class caveChest : MonoBehaviour {

    public GameObject openedChest1;
    private bool inArea = false;
    public Text interactText;

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
            interactText.text = "Press 'space' to interact with object.";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = false;
            interactText.text = "";
        }
    }

    void Update()
    {
        if (inArea && Input.GetKeyDown("space") && Game.current.chestUnlocked)
        {
            Game.current.player.gold = Game.current.player.gold + 10000000;
            Game.current.caveChestLooted = true;
            openedChest1.transform.position = new Vector3((float)13.808, (float)3.859, 0);
            GameObject.Destroy(this.gameObject);
            interactText.text = "Inside the chest, you find 10,000,000 gold. I wonder who left this here.";
        }
        else if (inArea && Input.GetKeyDown("space") && !Game.current.chestUnlocked)
        {
            interactText.text = "The chest seems to be locked. Perhaps there is a way to unlock it somehow.";
        }
    }

}
