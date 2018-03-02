using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddToPartyAndBackToMap : MonoBehaviour {

    void OnMouseDown()
    {
        int spot = 0;
        foreach (Character character in Game.current.party)
        {
            if (character == null)
            {
                Game.current.party[spot] = Game.current.cat;
                Game.current.catInParty = true;
                Game.current.player.milk = false;
                break;
            }
            spot++;
        }
        SceneManager.LoadScene("main_map");
    }
}
