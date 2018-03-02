using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton1 : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    private void OnMouseDown()
    {
        camera1.gameObject.SetActive(false);
        if (Game.current.player.gold < 10)
        {
            camera3.gameObject.SetActive(true);
        }else
        {
            camera2.gameObject.SetActive(true);
        }
    }
}
