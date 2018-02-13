using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These functions are for testing
//Add a character to the player party
//Add a character to the enemy party
//Update Character Boss to a boss character

public class TestScript_AddPartyMember : MonoBehaviour {

     //temp Character
     public Character bob;

     public void addPartyMemberOnClick(int partyMember)
     {
          if (partyMember == 0)
          {
               bob = Game.current.cat;
          }
          else if (partyMember == 1)
          {
               bob = Game.current.sheep;
          }
          //party member = 2
          else
               bob = Game.current.drunkard;

          Game.current.party[partyMember] = bob;
     }

     public void addEnemyOnClick(int enemy)
     {
          if (enemy == 0)
          {
               bob = Game.current.rat1;
          }
          else if (enemy == 1)
          {
               bob = Game.current.bear1;
          }
          else if (enemy == 2)
          {
               bob = Game.current.jelly1;
          }
          //enemy == 3
          else
               bob = Game.current.rat2;

          Game.current.enemyParty[enemy] = bob;
     }

     public void addBossOnClick(int b)
     {
          if (b == 0)
          {
               bob = Game.current.unicorn;
          }
          else if (b == 1)
          {
               bob = Game.current.goblin;
          }
          //b = 2
          else
               bob = Game.current.ink;

          Game.current.boss= bob;
     }

}
