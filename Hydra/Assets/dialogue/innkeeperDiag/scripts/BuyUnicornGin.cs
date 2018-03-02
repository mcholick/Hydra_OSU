using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyUnicornGin : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    private void OnMouseDown()
    {
        camera1.gameObject.SetActive(false);
        if (Game.current.player.gold < 1)
        {
            camera3.gameObject.SetActive(true);
        }
        else
        {
            if (Game.current.player.booze || Game.current.drunkInParty || Game.current.boozeOnGround)
            {
                camera2.gameObject.SetActive(true);
            }
            else
            {
                Game.current.boozeOnGround = true;
                Game.current.player.gold = Game.current.player.gold - 1;
                SceneManager.LoadScene("main_map");
            }
        }
    }
}
