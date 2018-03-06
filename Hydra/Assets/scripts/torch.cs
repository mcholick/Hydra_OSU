using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class torch : MonoBehaviour {

    public GameObject blueTorch;
    private bool inArea = false;
    public Text interactText;

    // Use this for initialization
    void Start()
    {
        if (Game.current.chestUnlocked == true || Game.current.caveChestLooted == true)
        {
            blueTorch.transform.position = transform.position;
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
        if (inArea && Input.GetKeyDown("space"))
        {
            blueTorch.transform.position = transform.position;
            Game.current.chestUnlocked = true;
            GameObject.Destroy(this.gameObject);
            interactText.text = "You fiddle with the torch. It turns blue and you hear a click.";
        }
    }
}
