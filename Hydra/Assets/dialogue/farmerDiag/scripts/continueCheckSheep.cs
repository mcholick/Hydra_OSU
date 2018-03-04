using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueCheckSheep : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;

    private void OnMouseDown()
    {
        camera1.gameObject.SetActive(false);
        if (Game.current.sheepDead)
        {
            camera4.gameObject.SetActive(true);
        }
        else
        {
            if (Game.current.player.gold < 10)
            {

                camera3.gameObject.SetActive(true);

            }
            else
            {
                camera2.gameObject.SetActive(true);
            }
        }
    }
}
