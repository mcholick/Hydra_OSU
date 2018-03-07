using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class door : MonoBehaviour {

    public Text interactText;
    private bool inArea = false;

    // Use this for initialization
    void Start () {
		if(Game.current.player.door == true)
        {
            GameObject.Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = true;
            interactText.text = "You need the heads of conjoined goblins and a unicorn horn to open this door. \nPress 'space' to interact with the door.";
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
        if (inArea && Input.GetKeyDown("space") && Game.current.player.heads && Game.current.player.horn)
        {
            Game.current.player.door = true;
            Game.current.player.heads = false;
            Game.current.player.horn = false;
            GameObject.Destroy(this.gameObject);
        }else if (inArea && Input.GetKeyDown("space"))
        {
            interactText.text = "You need the heads of conjoined goblins and a unicorn horn to open this door.";
        }
    }
}
