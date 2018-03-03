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
                        Game.current.enemyParty[i] = new Character(Game.current.rat);
                        print("making a rat");
                        break;
                    case 1:
                        Game.current.enemyParty[i] = new Character(Game.current.bear);
                        break;
                    default:
                        Game.current.enemyParty[i]= new Character(Game.current.jelly);
                        break;
                }
            }
            //SceneManager.LoadScene("_BattleScene");
        }
        
	}
}
