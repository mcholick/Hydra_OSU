using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript_AddPartyMember : MonoBehaviour {

     //what party member are you adding?
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
}
