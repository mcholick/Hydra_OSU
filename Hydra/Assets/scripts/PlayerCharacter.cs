using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class to hold player characters information
 *  Character
 *  array? inventory?
 *  
 * sub class:
 *        Character
 */
[System.Serializable]
public class PlayerCharacter {
     public Character hero;
     public List<string> inventory;

     public PlayerCharacter(){
          hero = new Character("Hero");
          inventory = new List<string>();
     }

}
