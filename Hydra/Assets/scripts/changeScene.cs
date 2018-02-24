using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

    public GameObject heads;

    void Start()
    {
        if (Game.current.player.goblins == true)
        {
            if (Game.current.player.heads == false)
            {
                heads.transform.position = transform.position;
            }
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         SceneManager.LoadScene("_BattleScene");
        //Destroy(self.gameObject);
    }

}
