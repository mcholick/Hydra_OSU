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
     public int maxhealth;
     public int currenthealth;
     public int strength;
     public int dexterity;
     public int wisdom;
     public int piety;
     public int resistance;


     public Character (string n , int h , int s, int d, int w, int p, int r)
     {

          this.name = n;
          this.maxhealth = h;
          this.currenthealth = h;
          this.strength = s;
          this.dexterity = d;
          this.wisdom = w;
          this.piety = p;
          this.resistance = r;

     }

}
