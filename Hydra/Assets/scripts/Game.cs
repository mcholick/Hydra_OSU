using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Game class
 * 
 * sub classes:
 *        Character
 *        WIP: Enem
 */

[System.Serializable]
public class Game {

     public static Game current;
     public Character player;
     public Character farmer;
     public Character sheep;
     public Character cat;
     public Character drunkard;
     public Character[] party;


     public Game()
     {
          //-------------IMPORTANT NOTE: if you change any of the character names, please update if statment names in Update_CharacterMenu!
          player = new Character("Hero",20,5,5,5,5,0);
          farmer = new Character("Farmer Frank", 25,10,6,1,1,2);
          sheep = new Character("Shifty Sheep",15,2,8,9,1,3);
          cat = new Character("Clumsy Cat",15,3,8,2,8,3);
          drunkard = new Character("Drunkard Dan",30,10,4,1,0,5);

          //initalize array to hold party
          //max 4 party members and player is one of them
          party = new Character[3];
          party[0] = null;
          party[1] = null;
          party[2] = null;


     }

}
