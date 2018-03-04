using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddDrunkMap : MonoBehaviour {

    void OnMouseDown()
    {
        int spot = 0;
        foreach (Character character in Game.current.party)
        {
            if (character == null)
            {
                Game.current.party[spot] = Game.current.drunkard;
                Game.current.drunkInParty = true;
                break;
            }
            spot++;
        }
        SceneManager.LoadScene("main_map");
    }
}
