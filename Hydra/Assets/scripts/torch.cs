using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour {

    public GameObject blueTorch;
    private bool inArea = false;

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
            blueTorch.transform.position = transform.position;
            Game.current.chestUnlocked = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
