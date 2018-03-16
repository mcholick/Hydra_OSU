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
    public Character cow;
    public Character cat;
    public Character drunkard;
    public string[] inventory;
    public float HeroX = 0;
    public float HeroY = 0;


     public Character unicorn;
     public Character goblin;
     public Character ink;

     //---------Random Encounter Enemies-----
     //could have multiple in encounter, max enemy count in encounter is 4
     public Character bear;

     public Character rat;

     public Character jelly;


     public Character boss;
     public Character[] party;
     public Character[] enemyParty;

    public bool chestUnlocked;
    public bool caveChestLooted;
    public bool mazeChestLooted;

    public bool farmerInParty;
    public bool sheepInParty;
    public bool catInParty;
    public bool drunkInParty;
    public bool cowDead;
    public bool sheepDead;
    public bool farmerDead;
    public bool milkOnGround;
    public bool boozeOnGround;
    public bool gotMilk;


    public Game()
     {
          //-------------IMPORTANT NOTE: if you change any of the charactertype names (first Character element), please update if statment names in Update_CharacterMenu.cs, and Battle_Mechanics.cs!----------------------
          player = new Character("heroine", "Hero",30,5,5,5,5,0);
          farmer = new Character("farmer","Farmer Frank", 35,10,6,1,1,2);
          sheep = new Character("sheep","Shifty Sheep",25,2,8,9,1,3);
          cat = new Character("cat","Clumsy Cat",25,3,8,2,8,3);
          drunkard = new Character("drunkard","Drunkard Dan",40,10,4,1,0,5);
          cow = new Character("cow", "Heifer Cow", 5, 5, 5, 5, 5, 5);

        chestUnlocked = false;
        caveChestLooted = false;
        farmerInParty = false;
        sheepInParty = false;
        catInParty = false;
        drunkInParty = false;
        cowDead = false;
        sheepDead = false;
        farmerDead = false;
        milkOnGround = false;
        mazeChestLooted = false;
        boozeOnGround = false;
        gotMilk = false;

          //-----IMPORTANT: HEALTH IS CHANGED FOR DEBUGING...INCREASE HEALTH FOR SUBMISSON!!!-----------
        unicorn = new Character("unicorn","Sassy Unicorn",100,3,5,8,9,3);
          goblin = new Character("goblin","Goblin Twins",500,10,1,1,2,5);
          ink = new Character("ink","Amorphous Ink Blot",1000,10,9,8,7,5);

          bear = new Character("bear","Bear",15,6,5,2,0,1);
         // bear[1] = new Character("bear", "Bear 2", 30, 8, 5, 2, 0, 1);
          //bear[2] = new Character("bear", "Bear 3", 30, 8, 5, 2, 0, 1);
          //bear[3] = new Character("bear", "Bear 4", 30, 8, 5, 2, 0, 1);

          rat = new Character("rat","Rat",5,2,7,1,1,0);
          //rat[1] = new Character("rat", "Rat 2", 10, 2, 7, 1, 1, 0);
          //rat[2] = new Character("rat", "Rat 3", 10, 2, 7, 1, 1, 0);
          //rat[3] = new Character("rat", "Rat 4", 10, 2, 7, 1, 1, 0);

          jelly = new Character("jelly","Jelly",10,4,7,2,1,1);
          //jelly[1] = new Character("jelly", "Jelly 2", 20, 5, 7, 2, 1, 1);
          //jelly[2] = new Character("jelly", "Jelly 3", 20, 5, 7, 2, 1, 1);
          //jelly[3] = new Character("jelly", "Jelly 4", 20, 5, 7, 2, 1, 1);


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
