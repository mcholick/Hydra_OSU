using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMechanic : MonoBehaviour {

     public int partyMember;
     public Button levelUpButton;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(partyMember == 0)
          {
               //hide button if 0 points to commit
               if(Game.current.player.skillPoints >0)
               {
                    levelUpButton.gameObject.SetActive(true);
               }
               else
               {
                    levelUpButton.gameObject.SetActive(false);
               }
          }
          else if ((partyMember == 1) && (Game.current.party[0] != null))
          {
               
               if (Game.current.party[0].skillPoints > 0)
               {
                    levelUpButton.gameObject.SetActive(true);
               }
               else
               {
                    levelUpButton.gameObject.SetActive(false);
               }
          }
          else if ((partyMember == 2) && (Game.current.party[1] != null))
          {

               if (Game.current.party[1].skillPoints > 0)
               {
                    levelUpButton.gameObject.SetActive(true);
               }
               else
               {
                    levelUpButton.gameObject.SetActive(false);
               }
          }
          else if ((partyMember == 3) && (Game.current.party[2] != null))
          {
              
               if (Game.current.party[2].skillPoints > 0)
               {
                    levelUpButton.gameObject.SetActive(true);
               }
               else
               {
                    levelUpButton.gameObject.SetActive(false);
               }
          }
     }
}
