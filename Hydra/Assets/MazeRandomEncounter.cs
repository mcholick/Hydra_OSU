using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeRandomEncounter : MonoBehaviour {
    public GameObject focus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Game.current.HeroX = focus.transform.position.x;
        //Game.current.HeroY = focus.transform.position.y;
        if (Mathf.Abs(focus.transform.position.x + focus.transform.position.y)*1123555%4000 > 3990) {
            print("HeroX is " + Game.current.HeroX.ToString());
            //SceneManager.LoadScene("_BattleScene");
        }
        
	}
}
