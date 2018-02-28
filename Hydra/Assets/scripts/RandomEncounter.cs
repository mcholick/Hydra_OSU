using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour {
    public GameObject focus;
    bool Debug = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Game.current.HeroX = focus.transform.position.x;
        //Game.current.HeroY = focus.transform.position.y;
        if (Mathf.Abs(focus.transform.position.x + focus.transform.position.y)*1123555%4000 > 3200) {
            //print("HeroX is " + Game.current.HeroX.ToString());
            //SceneManager.LoadScene("_BattleScene");
            int enemyCount = Random.Range(0, 3);    //random number of enemies
            if (Debug)
                enemyCount = 1;

            for (int i = 0; i <= enemyCount; i++) {
                int enemyType = Random.Range(0, 2);  //dictates enemy type
                if (Debug)
                    enemyType = 0;
                
                switch (enemyType)
                {
                    case 0:
                        Game.current.enemyParty[i] = new Character("rat", "Rat", 10, 2, 7, 1, 1, 0);
                        print("making a rat");
                        break;
                    case 1:
                        Game.current.enemyParty[i] = new Character("bear", "Bear", 30, 8, 5, 2, 0, 1);
                        break;
                    default:
                        Game.current.enemyParty[i]= new Character("jelly", "Jelly", 20, 5, 7, 2, 1, 1);
                        break;
                }
            }
            //SceneManager.LoadScene("_BattleScene");
        }
        
	}
}
