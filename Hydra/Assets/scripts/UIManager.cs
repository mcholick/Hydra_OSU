using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Ref: https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
 */
public class UIManager : MonoBehaviour {
     GameObject[] pauseObjects;
	// Use this for initialization
	void Start () {
          Time.timeScale = 1;
          pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
          hidePaused();
	}
	
	// Update is called once per frame
	void Update () {
          //if player pushed down esc to pause
          if (Input.GetKeyDown(KeyCode.Escape))
          {
               if (Time.timeScale == 1)
               {
                    Time.timeScale = 0;
                    showPaused();
               }
               else if (Time.timeScale == 0)
               {
                    Debug.Log("High");
                    Time.timeScale = 1;
                    hidePaused();
               }
          }
	}

     public void showPaused()
     {
          foreach(GameObject g in pauseObjects)
          {
               g.SetActive(true);
          }
     }

     public void hidePaused()
     {
          foreach(GameObject g in pauseObjects)
          {
               g.SetActive(false);
          }
     }
}
