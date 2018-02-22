using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour {

     public int WhichBoss;

    void OnTriggerEnter2D(Collider2D other)
     {
          Debug.Log("addBossToBattle");

          if (WhichBoss == 1)
          {
               //first boss unicorn
               Game.current.boss = Game.current.unicorn;
               Game.current.player.unicorn = true;
        }
          else if (WhichBoss == 2)
          {
               Debug.Log("boss is set?");
               //second boss goblin
               Game.current.boss = Game.current.goblin;
               Debug.Log(Game.current.boss);
               Game.current.player.goblins = true;
        }
          else
          {
               //third boss ink blot
               Game.current.boss = Game.current.ink;
          }
     }
}
