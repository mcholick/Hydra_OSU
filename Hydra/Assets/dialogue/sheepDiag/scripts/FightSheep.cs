using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightSheep : MonoBehaviour {

    void OnMouseDown()
    {
        Game.current.boss = Game.current.sheep;
        Game.current.sheepDead = true;
        SceneManager.LoadScene("_BattleScene");
    }
}
