using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowFarmerDeadCheck : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;

    private void OnMouseDown()
    {
        camera1.gameObject.SetActive(false);
        if (Game.current.player.gold < 10)
        {
            if (Game.current.farmerDead)
            {
                camera4.gameObject.SetActive(true);
            }
            else
            {
                camera3.gameObject.SetActive(true);
            }
        }
        else
        {
            camera2.gameObject.SetActive(true);
        }
    }
}
