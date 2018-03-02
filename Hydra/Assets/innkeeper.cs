using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class innkeeper : MonoBehaviour {

    private bool inArea = false;

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
            Game.current.interactionChar = 3;
            SceneManager.LoadScene("interactionScene");
        }
    }
}
