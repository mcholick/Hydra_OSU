using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
/*
 * Attaches to input Field
 * When player clicks off field
 * Updates hero name
 */
public class UpdateHeroName : MonoBehaviour {

     public void setHeroName(string value)
     {
          Debug.Log("Hero's name was " + Game.current.player.name);
          Game.current.player.name = value;
          Debug.Log("Hero's name is now " + Game.current.player.name);
                   
     }
}
