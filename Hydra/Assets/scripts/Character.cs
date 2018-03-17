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
public class Character
{

    public string charactertype;
    public string name;
    public int maxhealth;
    public int currenthealth;
    public int strength;
    public int dexterity;
    public int wisdom;
    public int piety;
    public int resistance;
    public double gold;
    public int xp;
    public float x;
    public float y;
    public float z;
    public bool goblins;
    public bool unicorn;
    public bool finalBoss;
    public bool milk;
    public bool horn;
    public bool heads;
    public bool booze;
    public bool door;
    public int level;
    public int skillPoints;
    public int xpToLvl;


     public Character(string ct, string n, int h, int s, int d, int w, int p, int r)
    {
        this.charactertype = ct;
        this.name = n;
        this.maxhealth = h;
        this.currenthealth = h;
        this.strength = s;
        this.dexterity = d;
        this.wisdom = w;
        this.piety = p;
        this.resistance = r;
        this.gold = 0;
        this.xp = 0;
        this.x = 0;
        this.y = 3;
        this.z = 0;
        this.goblins = false;
        this.unicorn = false;
        this.milk = false;
        this.horn = false;
        this.heads = false;
        this.booze = false;
        this.door = false;
        this.level = 1;
        this.finalBoss = true;
        this.skillPoints = 0;
        this.xpToLvl = 100;

    }
    //clone copy for battles
    public Character(Character c)
    {
        this.charactertype = c.charactertype;
        this.name = c.name;
        this.maxhealth = c.maxhealth;
        this.currenthealth = c.currenthealth;
        this.strength = c.strength;
        this.dexterity = c.dexterity;
        this.wisdom = c.wisdom;
        this.piety = c.piety;
        this.resistance = c.resistance;
        this.level = c.level;
    }

    public void CopyCharacter(Character source)
    {
        this.charactertype = source.charactertype;
        this.name = source.name;
        this.maxhealth = source.maxhealth;
        this.currenthealth = source.currenthealth;
        this.strength = source.strength;
        this.dexterity = source.dexterity;
        this.wisdom = source.wisdom;
        this.piety = source.piety;
        this.resistance = source.resistance;
        this.level = source.level;
    }

    public bool addXp(int xpAdd)
    {
        this.xp = this.xp + xpAdd;
        bool leveled = false;
        while(this.xp >= this.xpToLvl)
        {
            this.skillPoints++;
            this.level++;
            this.xpToLvl = this.xpToLvl + this.xpToLvl;
            leveled = true;
        }
        return leveled;
    }
}
