using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Ref: https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
 */
public class UIManager : MonoBehaviour {
     GameObject[] pauseObjects;
     GameObject[] characterMenu;
     GameObject[] levelUp;
     GameObject[] levelUpPanel;
	// Use this for initialization
	void Start () {
          Time.timeScale = 1;
          pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
          characterMenu = GameObject.FindGameObjectsWithTag("characterMenu");
          levelUp = GameObject.FindGameObjectsWithTag("level_Up");
          levelUpPanel = GameObject.FindGameObjectsWithTag("level_up_panel");

          hidePaused();
          hideCharacterMenuOnClick();
          hideLevelUp();
          hideLevelUpPanel();
     }
	
	// Update is called once per frame
	void Update () {
          //if player pushed down esc to pause
          if (Input.GetKeyDown(KeyCode.Escape))
          {
               if (Time.timeScale == 1)
               {
                    showPaused();
               }
          }
	}

     public void showPaused()
     {
          foreach(GameObject g in pauseObjects)
          {
               Time.timeScale = 0;
               g.SetActive(true);   
          }
     }

     public void hidePaused()
     {
          foreach(GameObject g in pauseObjects)
          {
               Time.timeScale = 1;
               g.SetActive(false);
          }
     }

     //function so on button click show character menu from pause screen
     public void showCharacterMenuOnClick()
     {
          foreach(GameObject g in characterMenu)
          {
               g.SetActive(true);
          }
     }

     public void hideCharacterMenuOnClick()
     {
          foreach (GameObject g in characterMenu)
          {
               g.SetActive(false);
          }
     }

     public void hideLevelUp()
     {
          foreach (GameObject g in levelUp)
          {
               g.SetActive(false);
          }
     }

     public void showLevelUpPanel()
     {
          foreach (GameObject g in levelUpPanel)
          {
               g.SetActive(true);
          }
     }

     public void hideLevelUpPanel()
     {
          foreach (GameObject g in levelUpPanel)
          {
               g.SetActive(false);
          }
     }
}
