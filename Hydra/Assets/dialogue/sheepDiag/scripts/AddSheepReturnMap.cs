using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddSheepReturnMap : MonoBehaviour {

    void OnMouseDown()
    {
        int spot = 0;
        foreach (Character character in Game.current.party)
        {
            if (character == null)
            {
                Game.current.party[spot] = Game.current.sheep;
                Game.current.sheepInParty = true;
                break;
            }
            spot++;
        }
        SceneManager.LoadScene("main_map");
    }
}
