using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
     public PlayerCharacter player;
     public Character farmer;
     public Character sheep;
     public Character cat;
     public Character drunkard;

     public Game()
     {
          player = new PlayerCharacter();
          farmer = new Character("Farmer Frank");
          sheep = new Character("Shifty Sheep");
          cat = new Character("Clumsy Cat");
          drunkard = new Character("Drunkard Dan");

     }

}
