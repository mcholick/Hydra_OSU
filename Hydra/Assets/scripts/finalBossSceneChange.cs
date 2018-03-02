using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalBossChangeScene : MonoBehaviour
{

    void Start()
    {
        if (Game.current.player.finalBoss == true)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("_BattleScene");
        //Destroy(self.gameObject);
    }

}

