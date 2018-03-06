using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounter : MonoBehaviour {
    public GameObject focus;
    bool Debug = false;
    bool activateEncounters = false;
    float HeroX;
    float HeroY;
    float random;
    int encounterChance = 0; //as this increases, fight probability does too.
	// Use this for initialization
	void Start () {
        HeroX = focus.transform.position.x;
        HeroY = focus.transform.position.y;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activateEncounters = true;
        print("Encounters can now occur");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activateEncounters = false;
        print("Encounters can no longer occur");
    }

    // Update is called once per frame
    void Update () {
        random = Random.Range(1, 3500);
        //Game.current.HeroX = focus.transform.position.x;
        //Game.current.HeroY = focus.transform.position.y;
        if (activateEncounters == true)
        {
            //as hero moves around, increase chance of battle.
            if (HeroX != focus.transform.position.x) {
                encounterChance++;
                HeroX = focus.transform.position.x;
            }

            if (HeroY != focus.transform.position.y) {
                encounterChance++;
                HeroY = focus.transform.position.y;
            }

            if (encounterChance >= random)
            {
                encounterChance = 0;
                //print("HeroX is " + Game.current.HeroX.ToString());
                //SceneManager.LoadScene("_BattleScene");
                int enemyCount = Random.Range(0, 3);    //random number of enemies
                if (Debug)
                    enemyCount = 1;

                for (int i = 0; i <= enemyCount; i++)
                {
                    int enemyType = Random.Range(0, 2);  //dictates enemy type
                    if (Debug)
                        enemyType = 0;

                    switch (enemyType)
                    {
                        case 0:
                            Game.current.enemyParty[i] = new Character(Game.current.rat);
                            //print("making a rat");
                            break;
                        //case 1:
                          //  Game.current.enemyParty[i] = new Character(Game.current.bear);
                          //  break;
                        default:
                            Game.current.enemyParty[i] = new Character(Game.current.jelly);
                            break;
                    }
                }
                SceneManager.LoadScene("_BattleScene");
            }
        }
        
	}
}
