using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_CharacterMenu : MonoBehaviour {

     public Image spr;
     public int partyMember;
     public Text char_name;
     public Text health;
     public Text strength;
     public Text dexterity;
     public Text wisdom;
     public Text piety;
     public Text resistance;

	// Update is called once per frame
	void Update () {
          //check to see if player
          if (partyMember == 0)
          {
               spr.enabled = true;
               spr.sprite = Resources.Load("heroine", typeof(Sprite)) as Sprite;
               //spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
               char_name.text = Game.current.player.name;
               health.text = "Health: " + (Game.current.player.currenthealth).ToString() + " / " + (Game.current.player.maxhealth).ToString();
               strength.text = "Strength: " + (Game.current.player.strength).ToString();
               dexterity.text = "Dexterity: " + (Game.current.player.dexterity).ToString();
               wisdom.text = "Wisdom: " + (Game.current.player.wisdom).ToString();
               piety.text = "Piety: " + (Game.current.player.piety).ToString();
               resistance.text = "Resistance: " + (Game.current.player.resistance).ToString();
          }
          //check to see if have 2nd party member
          else if ((partyMember == 1) && (Game.current.party[0] != null))
          {
               spr.enabled = true;
               char_name.text = Game.current.party[0].name;
               
               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if(char_name.text == "Shifty Sheep")
               {
                    spr.sprite= Resources.Load("sheep", typeof(Sprite)) as Sprite;
               }
               else if(char_name.text == "Farmer Frank")
               {
                    spr.sprite =Resources.Load("farmer", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Clumsy Cat")
               {
                    spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Drunkard Dan")
               {
                    spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.party[0].currenthealth).ToString() + " / " + (Game.current.party[0].maxhealth).ToString();
               strength.text = "Strength: " + (Game.current.party[0].strength).ToString();
               dexterity.text = "Dexterity: " + (Game.current.party[0].dexterity).ToString();
               wisdom.text = "Wisdom: " + (Game.current.party[0].wisdom).ToString();
               piety.text = "Piety: " + (Game.current.party[0].piety).ToString();
               resistance.text = "Resistance: " + (Game.current.party[0].resistance).ToString();
          }
          //check to see if have 3rd party member
          else if ((partyMember == 2) && (Game.current.party[1] != null))
          {
               char_name.text = Game.current.party[1].name;
               spr.enabled = true;
               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_name.text == "Shifty Sheep")
               {
                    spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Farmer Frank")
               {
                    spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Clumsy Cat")
               {
                    spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Drunkard Dan")
               {
                    spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               
               health.text = "Health: " + (Game.current.party[1].currenthealth).ToString() + " / " + (Game.current.party[1].maxhealth).ToString();
               strength.text = "Strength: " + (Game.current.party[1].strength).ToString();
               dexterity.text = "Dexterity: " + (Game.current.party[1].dexterity).ToString();
               wisdom.text = "Wisdom: " + (Game.current.party[1].wisdom).ToString();
               piety.text = "Piety: " + (Game.current.party[1].piety).ToString();
               resistance.text = "Resistance: " + (Game.current.party[1].resistance).ToString();
          }
          //check to see if have 4th party member
          else if ((partyMember == 3) && (Game.current.party[2] != null))
          {

               char_name.text = Game.current.party[2].name;
               spr.enabled = true;
               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_name.text == "Shifty Sheep")
               {
                    spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Farmer Frank")
               {
                    spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Clumsy Cat")
               {
                    spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
               }
               else if (char_name.text == "Drunkard Dan")
               {
                    spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------
               
               health.text = "Health: " + (Game.current.party[2].currenthealth).ToString() + " / " + (Game.current.party[2].maxhealth).ToString();
               strength.text = "Strength: " + (Game.current.party[2].strength).ToString();
               dexterity.text = "Dexterity: " + (Game.current.party[2].dexterity).ToString();
               wisdom.text = "Wisdom: " + (Game.current.party[2].wisdom).ToString();
               piety.text = "Piety: " + (Game.current.party[2].piety).ToString();
               resistance.text = "Resistance: " + (Game.current.party[2].resistance).ToString();
          }
          //if none must be empty then set all blank
          else
          {
               spr.enabled = false;
               char_name.text = "";
               health.text = "";
               strength.text = "";
               dexterity.text = "";
               wisdom.text = "";
               piety.text = "";
               resistance.text = "";
          }
     }
}
