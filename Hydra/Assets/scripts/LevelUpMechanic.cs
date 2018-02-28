using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMechanic : MonoBehaviour {

     public int partyMember;
     public Button levelUpButton;
     private int[] levels;
     private int xpNeeded;
	// Use this for initialization
	void Start () {
          //Array to hold the amount of xp needed to get to next level
          levels = new int[9] {25,50,100,250,400,800,1000,1500,2000};
	}
	
	// Update is called once per frame
	void Update () {
		if(partyMember == 0)
          {
               //get current level (player starts at level 1)
               xpNeeded = levels[Game.current.player.level - 1];
               //if current xp is equal or greater than needed
               if(Game.current.player.xp >= xpNeeded)
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
               //get current level (player starts at level 1)
               xpNeeded = levels[Game.current.party[0].level - 1];
               //if current xp is equal or greater than needed
               if (Game.current.party[0].xp >= xpNeeded)
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
               //get current level (player starts at level 1)
               xpNeeded = levels[Game.current.party[1].level - 1];
               //if current xp is equal or greater than needed
               if (Game.current.party[1].xp >= xpNeeded)
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
               //get current level (player starts at level 1)
               xpNeeded = levels[Game.current.party[2].level - 1];
               //if current xp is equal or greater than needed
               if (Game.current.party[2].xp >= xpNeeded)
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
