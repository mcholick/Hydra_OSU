using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class farmer : MonoBehaviour {

    private bool inArea = false;

    // Use this for initialization
    void Start()
    {
        if (Game.current.farmerInParty == true || Game.current.farmerDead == true)
        {
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
            Game.current.interactionChar = 1;
            SceneManager.LoadScene("interactionScene");
        }
    }
}
