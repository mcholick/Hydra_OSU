using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fightUnicorn : MonoBehaviour {

    void OnMouseDown()
    {
        Game.current.boss = Game.current.unicorn;
        Game.current.player.unicorn = true;
        SceneManager.LoadScene("_BattleScene");
    }
}
