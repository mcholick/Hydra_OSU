using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHeroName : MonoBehaviour {

     void Start() {
          Text heroName = GetComponent<Text>();
          heroName.text = Game.current.player.hero.name;
     }

}
