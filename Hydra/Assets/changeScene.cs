using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
         SceneManager.LoadScene("_BattleScene");
        //Destroy(self.gameObject);
    }

}
