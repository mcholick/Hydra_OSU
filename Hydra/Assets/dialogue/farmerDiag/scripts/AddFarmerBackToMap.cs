using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddFarmerBackToMap : MonoBehaviour {

    void OnMouseDown()
    {
        int spot = 0;
        foreach (Character character in Game.current.party)
        {
            if (character == null)
            {
                Game.current.party[spot] = Game.current.farmer;
                Game.current.farmerInParty = true;
                break;
            }
            spot++;
        }
        SceneManager.LoadScene("main_map");
    }
}
