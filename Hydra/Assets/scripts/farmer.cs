using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class farmer : MonoBehaviour {

    private bool inArea = false;
    public Text interactText;

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
            interactText.text = "Press 'space' to interact with the farmer.";
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
            SceneManager.LoadScene("farmerDialogue");
        }
    }
}
