using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


/*
 * Ref: https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
 */
public class Battle_UI : MonoBehaviour
{
     GameObject[] BattleUIMainObjects;
     GameObject[] AttackMenusObjects;
     GameObject[] PhysicalAttackMenuObjects;
     GameObject[] MagicAttackMenuObjects;
     GameObject[] HealMenuObjects;
     GameObject[] TalkMenusObjects;
     GameObject[] IntimidateMenuObjects;
     GameObject[] CharmMenuObjects;
     GameObject[] BribeMenuObjects;
     GameObject[] PlayerSelectObjects;
     GameObject[] EffectTextObjects;



     // Use this for initialization
     void Start()
     {

          BattleUIMainObjects = GameObject.FindGameObjectsWithTag("Battle_UI_Main");
          AttackMenusObjects = GameObject.FindGameObjectsWithTag("Attack_Menu");
          PhysicalAttackMenuObjects = GameObject.FindGameObjectsWithTag("Physical_Attack_Menu");
          MagicAttackMenuObjects = GameObject.FindGameObjectsWithTag("Magic_Attack_Menu");
          HealMenuObjects = GameObject.FindGameObjectsWithTag("Heal_Menu");
          TalkMenusObjects = GameObject.FindGameObjectsWithTag("Talk_Menu");
          IntimidateMenuObjects = GameObject.FindGameObjectsWithTag("Intimidate_Menu");
          CharmMenuObjects = GameObject.FindGameObjectsWithTag("Charm_Menu");
          BribeMenuObjects = GameObject.FindGameObjectsWithTag("Bribe_Menu");
          PlayerSelectObjects = GameObject.FindGameObjectsWithTag("Select_Menu");
          EffectTextObjects = GameObject.FindGameObjectsWithTag("Effects_Text");

          hideBattleUI();
          hideAttack();
          hidePhysical();
          hideMagical();
          hideHeal();
          hideTalk();
          hideIntimidate();
          hideCharm();
          hideBribe();
          hideSelect();
          hideEffectText();

     }

    //Battle UI main menu

     public void showBattleUI()
     {
          foreach (GameObject g in BattleUIMainObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideBattleUI()
     {
          foreach (GameObject g in BattleUIMainObjects)
          {
               g.SetActive(false);
          }
     }

     //Battle Attack Menus

     public void showAttack()
     {
          foreach (GameObject g in AttackMenusObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideAttack()
     {
          foreach (GameObject g in AttackMenusObjects)
          {
               g.SetActive(false);
          }
     }

     //Physical Attack menu
     public void showPhysical()
     {
          foreach (GameObject g in PhysicalAttackMenuObjects)
          {
               g.SetActive(true);
          }
     }

     public void hidePhysical()
     {
          foreach (GameObject g in PhysicalAttackMenuObjects)
          {
               g.SetActive(false);
          }
     }

     //Magical Attack Menu
     public void showMagical()
     {
          foreach (GameObject g in MagicAttackMenuObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideMagical()
     {
          foreach (GameObject g in MagicAttackMenuObjects)
          {
               g.SetActive(false);
          }
     }

     //Heal Menu
     public void showHeal()
     {
          foreach (GameObject g in HealMenuObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideHeal()
     {
          foreach (GameObject g in HealMenuObjects)
          {
               g.SetActive(false);
          }
     }

     //Talk Menu
     public void showTalk()
     {
          foreach (GameObject g in TalkMenusObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideTalk()
     {
          foreach (GameObject g in TalkMenusObjects)
          {
               g.SetActive(false);
          }
     }

     //Intimidate Menu
     public void showIntimidate()
     {
          foreach (GameObject g in IntimidateMenuObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideIntimidate()
     {
          foreach (GameObject g in IntimidateMenuObjects)
          {
               g.SetActive(false);
          }
     }

     //Charm Menu
     public void showCharm()
     {
          foreach (GameObject g in CharmMenuObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideCharm()
     {
          foreach (GameObject g in CharmMenuObjects)
          {
               g.SetActive(false);
          }
     }

     //Bribe Menu
     public void showBribe()
     {
          foreach (GameObject g in BribeMenuObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideBribe()
     {
          foreach (GameObject g in BribeMenuObjects)
          {
               g.SetActive(false);
          }
     }

     //Select Menu
     public void showSelect()
     {
          foreach (GameObject g in PlayerSelectObjects)
          {
               g.SetActive(true);
          }
     }

     public void hideSelect()
     {
          foreach (GameObject g in PlayerSelectObjects)
          {
               g.SetActive(false);
          }
     }

     //Effect Text
     public void hideEffectText()
     {
          foreach (GameObject g in EffectTextObjects)
          {
               g.SetActive(false);
          }
     }

}

