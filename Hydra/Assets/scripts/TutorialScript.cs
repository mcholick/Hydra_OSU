using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public Text interactText;
    private bool inArea = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = true;
            interactText.text = "There is a magic door to the north that you have to find a way through.\nUse 'WASD' to move your character.\nHold left shift to sprint while moving.\nAssist townspeople and they might join your party.\n To check your party and allocate skillpoints, press esc and click on 'Character Menu'.\n To save the game, press esc and click 'Save and Quit'.";
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
}
