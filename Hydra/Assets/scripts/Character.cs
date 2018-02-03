using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class to hold all character information
 * string , name
 * int , stats
 * 
 */
 [System.Serializable]
public class Character {

     public string name;
     public int health;
     public int strength;
     public int dexterity;
     public int wisdom;
     public int piety;
     public int resistance;

     public Character (string n)
     {
          this.name = n;
          this.health = 10;
          this.strength = 5;
          this.dexterity = 5;
          this.wisdom = 5;
          this.piety = 5;
          this.resistance = 0;

     }

}
