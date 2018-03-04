using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInkBlot : MonoBehaviour {

    void Start()
    {
        if (Game.current.player.finalBoss == true)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Game.current.player.finalBoss = true;
        SceneManager.LoadScene("_BattleScene");
        //Destroy(self.gameObject);
    }

}
