using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Mechanics : MonoBehaviour {

     public Battle_UI uiHandler;
     bool buttonClicked;
     private bool battleOver;

     //Characters-------------------------------
     private Character hero;
     private Character party1;
     private Character party2;
     private Character party3;

     private Character b;

     private Character enemy1;
     private Character enemy2;
     private Character enemy3;
     private Character enemy4;

     //----------LOGIC: based on D&D, turn order based on dexterity stat---------
     //List to store characters, to then sort by dext largest to smallest
     private List<Character> orderedChars;

     //To keep track of whose turn it is-------------------------------
     //max number of characters in play is 8 (4 player, 4 enemy)
     private Character currentTurn;
     private Character next1;
     private Character next2;
     private Character next3;
     private Character next4;
     private Character next5;
     private Character next6;
     private Character next7;
     private Character temp;

     //update visual turn tracker----------------
     public Image turn_current;
     public Image turn_1;
     public Image turn_2;
     public Image turn_3;
     public Image turn_4;
     public Image turn_5;
     public Image turn_6;
     public Image turn_7;
     private Sprite tempPic;

     //For Health Text, to update----------------
     public Text health_player;
     public Text health_party1;
     public Text health_party2;
     public Text health_party3;
     public Text health_enemy1;
     public Text health_enemy2;
     public Text health_enemy3;
     public Text health_enemy4;
     public Text health_b;

     //buttons to get player input---------------
     public Button melee1;
     public Text melee1chance;
     public Button melee2;
     public Text melee2chance;
     public Button melee3;
     public Text melee3chance;

     public Button magic1;
     public Text magic1chance;
     public Button magic2;
     public Text magic2chance;
     public Button magic3;
     public Text magic3chance;

     public Button heal1;
     public Text heal1amount;
     public Button heal2;
     public Text heal2amount;
     public Button heal3;
     public Text heal3amount;

     public Button intimidate1;
     public Text intimidate1chance;
     public Button intimidate2;
     public Text intimidate2chance;
     public Button intimidate3;
     public Text intimidate3chance;

     public Button charm1;
     public Text charm1chance;
     public Button charm2;
     public Text charm2chance;
     public Button charm3;
     public Text charm3chance;

     public Button bribe1;
     public Text bribe1chance;
     public Button bribe2;
     public Text bribe2chance;
     public Button bribe3;
     public Text bribe3chance;

     public Button option1;
     public Text option1text;
     public Button option2;
     public Text option2text;
     public Button option3;
     public Text option3text;
     public Button option4;
     public Text option4text;

     public Button runaway;
     public Text runawaychance;

     //Status Text to update when Turn is taken to inform player
     public Text enemyDamageText;
     public Text enemyHealText;
     public Text enemyOtherText;
     public Text playerDamageText;
     public Text playerHealText;
     public Text playerOtherText;

     // Use this for initialization
     void Start () {
          tempPic = null;
          battleOver = false;
          //init party , boss, and enemy party to null
          party1 = null;
          party2 = null;
          party3 = null;
          b = null;
          enemy1 = null;
          enemy2 = null;
          enemy3 = null;
          enemy4 = null;
          orderedChars = new List<Character>();

          //init hero
          hero = Game.current.player;
          orderedChars.Add(hero);

          
          //check for player party members
          if (Game.current.party[0] != null)
          {
               party1 = Game.current.party[0];
               orderedChars.Add(party1);
          }

          if (Game.current.party[1] != null)
          {
               party2 = Game.current.party[1];
               orderedChars.Add(party2);
          }

          if(Game.current.party[2] != null)
          {
               party3 = Game.current.party[2];
               orderedChars.Add(party3);
          }

          //check for boss
          if(Game.current.boss != null)
          {
               b = Game.current.boss;
               orderedChars.Add(b);
          }

          if(Game.current.enemyParty[0] != null)
          {
               enemy1 = Game.current.enemyParty[0];
               orderedChars.Add(enemy1);
          }
          if (Game.current.enemyParty[1] != null)
          {
               enemy2 = Game.current.enemyParty[1];
               orderedChars.Add(enemy2);
          }
          if (Game.current.enemyParty[2] != null)
          {
               enemy3 = Game.current.enemyParty[2];
               orderedChars.Add(enemy3);
          }
          if (Game.current.enemyParty[3] != null)
          {
               enemy4 = Game.current.enemyParty[3];
               orderedChars.Add(enemy4);
          }

          //figure out who goes first, seconds.....
          Character key;
          int i;
          int size = orderedChars.Count;
          for(int j = 1; j < size; j++)
          {
               key = orderedChars[j];
               i = j - 1;
               while(i>=0 && orderedChars[i].dexterity < key.dexterity)
               {
                    orderedChars[i + 1] = orderedChars[i];
                    i = i - 1;
               }
               orderedChars[i + 1] = key;
          }

          //---------------------------------------Turn Order display-----------------------------------
          turn_current.sprite = Resources.Load(orderedChars[0].charactertype, typeof(Sprite)) as Sprite;
          currentTurn = orderedChars[0];

          if (orderedChars.Count >= 2)
          {
               turn_1.sprite = Resources.Load(orderedChars[1].charactertype, typeof(Sprite)) as Sprite;
               next1 = orderedChars[1];
          }
          if(orderedChars.Count >= 3)
          {
               turn_2.sprite = Resources.Load(orderedChars[2].charactertype, typeof(Sprite)) as Sprite;
               next2 = orderedChars[2];

          }
          if (orderedChars.Count >= 4)
          {
               turn_3.sprite = Resources.Load(orderedChars[3].charactertype, typeof(Sprite)) as Sprite;
               next3 = orderedChars[3];
          }
          if (orderedChars.Count >= 5)
          {
               turn_4.sprite = Resources.Load(orderedChars[4].charactertype, typeof(Sprite)) as Sprite;
               next4 = orderedChars[4];
          }
          if (orderedChars.Count >= 6)
          {
               turn_5.sprite = Resources.Load(orderedChars[5].charactertype, typeof(Sprite)) as Sprite;
               next5 = orderedChars[5];
          }
          if (orderedChars.Count >= 7)
          {
               turn_6.sprite = Resources.Load(orderedChars[6].charactertype, typeof(Sprite)) as Sprite;
               next6 = orderedChars[6];
          }
          if (orderedChars.Count >= 8)
          {
               turn_7.sprite = Resources.Load(orderedChars[7].charactertype, typeof(Sprite)) as Sprite;
               next7 = orderedChars[7];
          }
          //-----------------------------------Turn order displayed-----------------------------------------

          //Battle...START!
          StartCoroutine(battle());
              
     }
     
     //coroutine so it can be paused for player input
     IEnumerator battle()
     {
          //loop battle until all enemys die or all players die
          while (battleOver == false)
          {
               Debug.Log("Battle Phase");

               //is it the players turn or not---------------------------
               if (currentTurn.charactertype == "heroine" || currentTurn.charactertype == "farmer" || currentTurn.charactertype == "sheep" || currentTurn.charactertype == "cat" || currentTurn.charactertype == "drunkard")
               {
                    Debug.Log("PlayerTurn");
                    playerTurn(currentTurn);

                    //wait for player to click button
                    while (buttonClicked == false)
                    {
                         yield return null;

                    }
                    //Debug.Log("did player turn happen?");
               }
               
               //enemy turn-----------------------------------------
               else
               {
                    Debug.Log("EnemyTurn");
                    enemyTurn(currentTurn);
                    //pause 2 seconds for enemy turn
                    yield return new WaitForSeconds(2);
               }

               //------turn has been taken, update turn order-----------------
               temp = currentTurn;
               tempPic = turn_current.sprite;

               currentTurn = next1;
               turn_current.sprite = turn_1.sprite;

               next1 = temp;
               turn_1.sprite = tempPic;

               if (next2 != null)
               {
                    next1 = next2;
                    turn_1.sprite = turn_2.sprite;

                    next2 = temp;
                    turn_2.sprite = tempPic;
               }
               if (next3 != null)
               {
                    next2 = next3;
                    turn_2.sprite = turn_3.sprite;

                    next3 = temp;
                    turn_3.sprite = tempPic;
               }
               if (next4 != null)
               {
                    next3 = next4;
                    turn_3.sprite = turn_4.sprite;

                    next4 = temp;
                    turn_4.sprite = tempPic;
               }
               if (next5 != null)
               {
                    next4 = next5;
                    turn_4.sprite = turn_5.sprite;

                    next5 = temp;
                    turn_5.sprite = tempPic;
               }
               if (next6 != null)
               {
                    next5 = next6;
                    turn_5.sprite = turn_6.sprite;

                    next6 = temp;
                    turn_6.sprite = tempPic;
               }
               if (next7 != null)
               {
                    next6 = next7;
                    turn_6.sprite = turn_7.sprite;

                    next7 = temp;
                    turn_7.sprite = tempPic;
               }
               //----------------------------- turn order has been updated-----

          }
          Debug.Log("Left Battle Phase");
     }

     //-----WIP ------------------------------------------
     public void enemyTurn(Character c)
     {
          uiHandler.hideBattleUI();
          //enemy does stuff...
     }

     /*  playerTurn(Character c)
      *   Input: The Character that is currently making a move 
      *   
      *   Player is shown the UI panel and can select from a multitude of options 
      *   (damage,heal,talk,runaway), some with sub menus
      *   
      *   This function is in charge of:
      *              displaying the Battle UI panel
      *              setting buttonClicked to false
      *              Calling choice() : 
      *                         which adds listerners to the buttons for player click
      */

     void playerTurn(Character c)
     {
          Debug.Log("In player Turn");
          //Debug.Log(c.name);
          updateChanceTexts(c);

          uiHandler.showBattleUI();
          buttonClicked = false;
          choice();

     }

     //Updates the text fields for the chance and amounts for player character c
     void updateChanceTexts(Character c)
     {
          //Melee Amount = Strength
          //Melee Chance = Strength + Dex ?
          float dex = c.dexterity;
          float str = c.strength;
          float wis = c.wisdom;
          float pie = c.piety;

          float damage = str;
          float percentChance = (dex/5) * 100;
          melee1chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";

          damage = str * 2;
          percentChance = (dex / 10) * 100;
          melee2chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";

          damage = str * 5;
          percentChance = (dex / 25) * 100;
          melee3chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";


          //Magic Amount = Wisdom
          //Magic Chance = Wisdom + dex?

          damage = wis;
          percentChance = (dex / 5) * 100;
          magic1chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";
                
          damage = wis * 2;
          percentChance = (dex / 10) * 100;
          magic2chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";

          damage = wis * 5;
          percentChance = (dex / 25) * 100;
          magic3chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";


          //Heal Amount = Piety
          //chance to crit: wisdom

          damage = pie;
          heal1amount.text = "Amount: " + (damage);
                    
          damage = pie;
          heal2amount.text = "Amount: " + (damage);
                   
          damage = Mathf.Floor(pie/4) * 2;
          heal3amount.text = "Amount: " + (damage);


          //Intimidate = Strength based
          percentChance = (str / 5) * 100;
          intimidate1chance.text = " Chance: " + (percentChance) + "%";

          percentChance = (str / 10) * 100;
          intimidate2chance.text = " Chance: " + (percentChance) + "%";

          percentChance = (dex / 25) * 100;
          intimidate3chance.text = " Chance: " + (percentChance) + "%";

          //Charm = Wisdom based
          percentChance = (wis / 5) * 100;
          charm1chance.text = " Chance: " + (percentChance) + "%";

          percentChance = (wis / 10) * 100;
          charm2chance.text = " Chance: " + (percentChance) + "%";

          percentChance = (wis / 25) * 100;
          charm3chance.text = " Chance: " + (percentChance) + "%";


          //Bribe = Dex based
          percentChance = (wis / 5) * 100;
          bribe1chance.text = " Chance: " + (percentChance) + "%";

          percentChance = (wis / 10) * 100;
          bribe2chance.text = " Chance: " + (percentChance) + "%";

          percentChance = (wis / 25) * 100;
          bribe3chance.text = " Chance: " + (percentChance) + "%";


          //Is it boss battle? If yes player CAN'T run
          //Dex based?
          
          //not a boss fight player CAN run
          if (Game.current.boss == null)
          {
               percentChance = (dex / 20) * 100;
               runawaychance.text = " Chance: " + (percentChance) + "%";
          }
          else
          {
               runawaychance.text = "NO CHANCE OF ESCAPE!";
          }

     }


     //Adds listeners to buttons for onClick()
     void choice()
     {
          //Debug.Log("choice");
          melee1.onClick.RemoveAllListeners();
          melee1.onClick.AddListener(delegate { melee(1); });

          melee2.onClick.RemoveAllListeners();
          melee2.onClick.AddListener(delegate { melee(2); });

          melee3.onClick.RemoveAllListeners();
          melee3.onClick.AddListener(delegate { melee(3); });

     
          magic1.onClick.RemoveAllListeners();
          magic1.onClick.AddListener(delegate { magic(1); });
   
          magic2.onClick.RemoveAllListeners();
          magic2.onClick.AddListener(delegate { magic(2); });
   
          magic3.onClick.RemoveAllListeners();
          magic3.onClick.AddListener(delegate { magic(3); });


          heal1.onClick.RemoveAllListeners();
          heal1.onClick.AddListener(delegate { heal(1); });

          heal2.onClick.RemoveAllListeners();
          heal2.onClick.AddListener(delegate { heal(2); });

          heal3.onClick.RemoveAllListeners();
          heal3.onClick.AddListener(delegate { heal(3); });


          runaway.onClick.RemoveAllListeners();
          runaway.onClick.AddListener(attemptRunaway);


          intimidate1.onClick.RemoveAllListeners();
          intimidate1.onClick.AddListener(delegate { intimidate(1); });

          intimidate2.onClick.RemoveAllListeners();
          intimidate2.onClick.AddListener(delegate { intimidate(2); });
 
          intimidate3.onClick.RemoveAllListeners();
          intimidate3.onClick.AddListener(delegate { intimidate(3); });


          charm1.onClick.RemoveAllListeners();
          charm1.onClick.AddListener(delegate { charm(1); });
   
          charm2.onClick.RemoveAllListeners();
          charm2.onClick.AddListener(delegate { charm(2); });
   
          charm3.onClick.RemoveAllListeners();
          charm3.onClick.AddListener(delegate { charm(3); });

     
          bribe1.onClick.RemoveAllListeners();
          bribe1.onClick.AddListener(delegate { bribe(1); });
    
          bribe2.onClick.RemoveAllListeners();
          bribe2.onClick.AddListener(delegate { bribe(2); });

          bribe3.onClick.RemoveAllListeners();
          bribe3.onClick.AddListener(delegate { bribe(3); });

     }

     //--------------------WIP------------------------
     void melee(int a)
     {
          if(a == 1)
          {
               buttonClicked = true;
               Debug.Log("melee1");
          }
          else if (a == 2)
          {
               buttonClicked = true;
               Debug.Log("melee2");
          }
          else//a = 3
          {
               buttonClicked = true;
               Debug.Log("melee3");
          }
               
     }

     //magic
     void magic(int a)
     {
          if (a == 1)
          {
               buttonClicked = true;
               Debug.Log("magic1");
          }
          else if (a == 2)
          {
               buttonClicked = true;
               Debug.Log("magic2");
          }
          else//a = 3
          {
               buttonClicked = true;
               Debug.Log("magic3");
          }

     }

     //heal
     void heal(int a)
     {
          if (a == 1)
          {
               buttonClicked = true;
               Debug.Log("heal1");
          }
          else if (a == 2)
          {
               buttonClicked = true;
               Debug.Log("heal2");
          }
          else//a = 3
          {
               buttonClicked = true;
               Debug.Log("heal3");
          }

     }

     //intimidate
     void intimidate(int a)
     {
          if (a == 1)
          {
               buttonClicked = true;
               Debug.Log("intimidate1");
          }
          else if (a == 2)
          {
               buttonClicked = true;
               Debug.Log("intimidate2");
          }
          else//a = 3
          {
               buttonClicked = true;
               Debug.Log("intimidate3");
          }

     }

     //charm
     void charm(int a)
     {
          if (a == 1)
          {
               buttonClicked = true;
               Debug.Log("charm1");
          }
          else if (a == 2)
          {
               buttonClicked = true;
               Debug.Log("charm2");
          }
          else//a = 3
          {
               buttonClicked = true;
               Debug.Log("charm3");
          }

     }

     //bribe
     void bribe(int a)
     {
          if (a == 1)
          {
               buttonClicked = true;
               Debug.Log("bribe1");
          }
          else if (a == 2)
          {
               buttonClicked = true;
               Debug.Log("bribe2");
          }
          else//a = 3
          {
               buttonClicked = true;
               Debug.Log("bribe3");
          }

     }

     //runaway?
     void attemptRunaway()
     {
          buttonClicked = true;
          Debug.Log("attempted to runaway");

     }
}
