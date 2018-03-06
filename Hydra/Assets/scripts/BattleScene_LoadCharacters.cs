using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleScene_LoadCharacters : MonoBehaviour {

     public Image spr;
     public int partyMember;
     public Text health;
     private string char_type;

     //Change to Text char_name if including names above characters
     //public string char_name;

     // Use this for initialization
     void Start () {

          if(Game.current.boss != null)
          {
               //boss no other party members
               Game.current.enemyParty[0] = null;
               Game.current.enemyParty[1] = null;
               Game.current.enemyParty[2] = null;
               Game.current.enemyParty[3] = null;
          }

          //-----------------Begin init of player party------------------------
          if (partyMember == 0)
          {
               Debug.Log("player Character");
               spr.enabled = true;
               health.enabled = true;
               spr.sprite = Resources.Load("heroine", typeof(Sprite)) as Sprite;
               //char_name.text = Game.current.player.name;
               health.text = "Health: " + (Game.current.player.currenthealth).ToString() + " / " + (Game.current.player.maxhealth).ToString();
               
          }
          //check to see if have 2nd party member
          else if ((partyMember == 1) && (Game.current.party[0] != null))
          {
               Debug.Log("Party member 1");
               spr.enabled = true;
               health.enabled = true;
               //char_name.text = Game.current.party[0].name;
               char_type = Game.current.party[0].charactertype;

               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "sheep")
               {
                    spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "farmer")
               {
                    spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "cat")
               {
                    spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "drunkard")
               {
                    spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.party[0].currenthealth).ToString() + " / " + (Game.current.party[0].maxhealth).ToString();
               
          }
          //check to see if have 3rd party member
          else if ((partyMember == 2) && (Game.current.party[1] != null))
          {
               Debug.Log("Party member 2");
               //char_name= Game.current.party[1].name;
               spr.enabled = true;
               health.enabled = true;
               char_type = Game.current.party[1].charactertype;

               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "sheep")
               {
                    spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "farmer")
               {
                    spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "cat")
               {
                    spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "drunkard")
               {
                    spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.party[1].currenthealth).ToString() + " / " + (Game.current.party[1].maxhealth).ToString();
              
          }
          //check to see if have 4th party member
          else if ((partyMember == 3) && (Game.current.party[2] != null))
          {
               Debug.Log("Party member 3");
               //char_name = Game.current.party[2].name;
               spr.enabled = true;
               health.enabled = true;
               char_type = Game.current.party[2].charactertype;
               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "sheep")
               {
                    spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "farmer")
               {
                    spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "cat")
               {
                    spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "drunkard")
               {
                    spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.party[2].currenthealth).ToString() + " / " + (Game.current.party[2].maxhealth).ToString();
              
          }
          //-------------------------End init of player party-------------------------

          //--------------Begin init of enemy party-----------------------------------
          
          //------Boss!!!!!!!------
         else if ((partyMember == 4) && (Game.current.boss != null)) 
          {
               Debug.Log("Boss");
               spr.enabled = true;
               health.enabled = true;
               char_type = Game.current.boss.charactertype;
               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "unicorn")
               {
                    spr.sprite = Resources.Load("unicorn", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "goblin")
               {
                    spr.sprite = Resources.Load("goblin", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "ink")
               {
                    spr.sprite = Resources.Load("ink", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "sheep")
               {
                   spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "farmer")
               {
                   spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
               }
            else if (char_type == "cow")
            {
                spr.sprite = Resources.Load("cow", typeof(Sprite)) as Sprite;
            }
            //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------
            health.text = "Health: " + (Game.current.boss.currenthealth).ToString() + " / " + (Game.current.boss.maxhealth).ToString();

          }
          
          //1st enemy in enemyParty
          else if ((partyMember == 5) && (Game.current.enemyParty[0] != null))
          {
               Debug.Log("Enemy 1");
               spr.enabled = true;
               health.enabled = true;
               //char_name.text = Game.current.enemyParty[1].name;
               char_type = Game.current.enemyParty[0].charactertype;

               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "bear")
               {
                    spr.sprite = Resources.Load("bear", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "rat")
               {
                    spr.sprite = Resources.Load("rat", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "jelly")
               {
                    spr.sprite = Resources.Load("jelly", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.enemyParty[0].currenthealth).ToString() + " / " + (Game.current.enemyParty[0].maxhealth).ToString();

          }
         
          //2nd enemy in enemyParty
          else if ((partyMember == 6) && (Game.current.enemyParty[1] != null))
          {
               Debug.Log("Enemy 2");
               //char_name= Game.current.enemyParty[1].name;
               spr.enabled = true;
               health.enabled = true;
               char_type = Game.current.enemyParty[1].charactertype;

               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "bear")
               {
                    spr.sprite = Resources.Load("bear", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "rat")
               {
                    spr.sprite = Resources.Load("rat", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "jelly")
               {
                    spr.sprite = Resources.Load("jelly", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.enemyParty[1].currenthealth).ToString() + " / " + (Game.current.enemyParty[1].maxhealth).ToString();

          }
         
          //3rd enemy in enemyParty
          else if ((partyMember == 7) && (Game.current.enemyParty[2] != null))
          {
               Debug.Log("Enemy 3");
               //char_name = Game.current.enemyParty[2].name;
               spr.enabled = true;
               health.enabled = true;
               char_type = Game.current.enemyParty[2].charactertype;
               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "bear")
               {
                    spr.sprite = Resources.Load("bear", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "rat")
               {
                    spr.sprite = Resources.Load("rat", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "jelly")
               {
                    spr.sprite = Resources.Load("jelly", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.enemyParty[2].currenthealth).ToString() + " / " + (Game.current.enemyParty[2].maxhealth).ToString();

          }

          //4th enemy in enemyParty
          else if ((partyMember == 8) && (Game.current.enemyParty[3] != null))
          {
               Debug.Log("Enemy 4");
               //char_name = Game.current.enemyParty[3].name;
               spr.enabled = true;
               health.enabled = true;
               char_type = Game.current.enemyParty[3].charactertype;
               //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
               if (char_type == "bear")
               {
                    spr.sprite = Resources.Load("bear", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "rat")
               {
                    spr.sprite = Resources.Load("rat", typeof(Sprite)) as Sprite;
               }
               else if (char_type == "jelly")
               {
                    spr.sprite = Resources.Load("jelly", typeof(Sprite)) as Sprite;
               }
               //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

               health.text = "Health: " + (Game.current.enemyParty[3].currenthealth).ToString() + " / " + (Game.current.enemyParty[3].maxhealth).ToString();

          }
          //if none must be empty then set all blank
          else
          {
               Debug.Log("Empty");
               spr.enabled = false;
               //char_name = "";
               health.enabled = false;

          }

     }//end start()


}

