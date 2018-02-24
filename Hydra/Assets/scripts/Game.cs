using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Game class
 * 
 * sub classes:
 *        Character
 *        
 */

[System.Serializable]
public class Game {



    public static Game current;
    public Character player;
    public Character farmer;
    public Character sheep;
    public Character cat;
    public Character drunkard;
    public string[] inventory; 

     public Character unicorn;
     public Character goblin;
     public Character ink;

     //---------Random Encounter Enemies-----
     //could have multiple in encounter, max enemy count in encounter is 4
     public Character bear1;
     public Character bear2;
     public Character bear3;
     public Character bear4;

     public Character rat1;
     public Character rat2;
     public Character rat3;
     public Character rat4;

     public Character jelly1;
     public Character jelly2;
     public Character jelly3;
     public Character jelly4;

     public Character boss;
     public Character[] party;
     public Character[] enemyParty;

    public bool chestUnlocked;
    public bool caveChestLooted;


     public Game()
     {
          //-------------IMPORTANT NOTE: if you change any of the charactertype names (first Character element), please update if statment names in Update_CharacterMenu.cs, and Battle_Mechanics.cs!----------------------
          player = new Character("heroine", "Hero",20,5,5,5,5,0);
          farmer = new Character("farmer","Farmer Frank", 25,10,6,1,1,2);
          sheep = new Character("sheep","Shifty Sheep",15,2,8,9,1,3);
          cat = new Character("cat","Clumsy Cat",15,3,8,2,8,3);
          drunkard = new Character("drunkard","Drunkard Dan",30,10,4,1,0,5);
        chestUnlocked = false;
        caveChestLooted = false;

        unicorn = new Character("unicorn","Sassy Unicorn",50,3,5,8,9,3);
          goblin = new Character("goblin","Goblin Twins",2,10,1,1,2,5);
          ink = new Character("ink","Amorphous Ink Blot",100,10,9,8,7,5);

          bear1 = new Character("bear","Bear",30,8,5,2,0,1);
          bear2 = new Character("bear", "Bear 2", 30, 8, 5, 2, 0, 1);
          bear3 = new Character("bear", "Bear 3", 30, 8, 5, 2, 0, 1);
          bear4 = new Character("bear", "Bear 4", 30, 8, 5, 2, 0, 1);

          rat1 = new Character("rat","Rat",10,2,7,1,1,0);
          rat2 = new Character("rat", "Rat 2", 10, 2, 7, 1, 1, 0);
          rat3 = new Character("rat", "Rat 3", 10, 2, 7, 1, 1, 0);
          rat4 = new Character("rat", "Rat 4", 10, 2, 7, 1, 1, 0);

          jelly1 = new Character("jelly","Jelly",20,5,7,2,1,1);
          jelly2 = new Character("jelly", "Jelly 2", 20, 5, 7, 2, 1, 1);
          jelly3 = new Character("jelly", "Jelly 3", 20, 5, 7, 2, 1, 1);
          jelly4 = new Character("jelly", "Jelly 4", 20, 5, 7, 2, 1, 1);


          //-----------------------------------------------------------------------------SEE IMPORTANT NOTE about character names



          //initalize array to hold party
          //max 4 party members and player is one of them
          party = new Character[3];
          party[0] = null;
          party[1] = null;
          party[2] = null;

          //initalize arry to hold enemies
          //max number of enemy character is 4
          //boss is NOT stored in enemy party
          enemyParty = new Character[4];
          enemyParty[0] = null;
          enemyParty[1] = null;
          enemyParty[2] = null;
          enemyParty[3] = null;

          //init boss to null 
          //Set boss if fight has boss in it
          boss = null;

          inventory = new string[4];

     }

}
