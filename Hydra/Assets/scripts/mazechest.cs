using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mazechest : MonoBehaviour {


    public GameObject openedChest2;
    private bool inArea = false;
    public Text interactText;

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
        if (inArea && Input.GetKeyDown("space") && Game.current.mazeChestLooted != true)
        {
            Game.current.player.gold = Game.current.player.gold + 98975643;
            Game.current.mazeChestLooted = true;
            openedChest2.transform.position = new Vector3((float)-26.465, (float)1.081, 0);
            GameObject.Destroy(this.gameObject);
            interactText.text = "Inside the chest, you find 98,975,643 gold. Wow!";
        }
    }

}
