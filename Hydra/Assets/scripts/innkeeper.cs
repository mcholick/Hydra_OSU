using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class innkeeper : MonoBehaviour {

    private bool inArea = false;
    public GameObject booze;
    public Text interactText;

    private void Start()
    {
        if (Game.current.boozeOnGround)
        {
            booze.transform.position = new Vector3((float)-2.556, (float)-2.283, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = true;
            interactText.text = "Press 'space' to interact with the innkeeper.";
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
            SceneManager.LoadScene("innkeeperDialogue");
        }
    }
}
