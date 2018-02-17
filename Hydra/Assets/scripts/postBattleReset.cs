using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class postBattleReset : MonoBehaviour {

     public void leaveBattle()
     {
          //change Load Scene Value to 2 for main_map
          SceneManager.LoadScene(2);
          Debug.Log("loading scene");
          postBattleUpdate();
     }

	public void postBattleUpdate()
     {
          Game.current.boss = null;
          Game.current.enemyParty[0] = null;
          Game.current.enemyParty[1] = null;
          Game.current.enemyParty[2] = null;
          Game.current.enemyParty[3] = null;
     }
     
          
               
}
