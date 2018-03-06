using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{

    public UIManager ui_manager;
    public Image spr;
    public Text char_name;
    public Text health;
    public Text strength;
    public Text dexterity;
    public Text wisdom;
    public Text piety;
    public Text resistance;
    private string char_type;

    public Text level_health;
    public Text level_strength;
    public Text level_dexterity;
    public Text level_wisdom;
    public Text level_piety;
    public Text level_resistance;

    private int l_health;
    private int l_str;
    private int l_dex;
    private int l_wis;
    private int l_piety;
    private int l_res;


    public Button h_Plus;
    public Button h_Minus;
    public Button s_Plus;
    public Button s_Minus;
    public Button d_Plus;
    public Button d_Minus;
    public Button w_Plus;
    public Button w_Minus;
    public Button p_Plus;
    public Button p_Minus;
    public Button r_Plus;
    public Button r_Minus;

    private Character person;
    private int points;
    private int totalpoints;
    public Text point_Text;

    private int character;

    public Button commit;

    public void levelUpCharacter(int c)
    {
        ui_manager.showLevelUpPanel();
        character = c;

        if (c == 0)
        {
            points = Game.current.player.skillPoints;
            totalpoints = Game.current.player.skillPoints;
            spr.enabled = true;
            spr.sprite = Resources.Load("heroine", typeof(Sprite)) as Sprite;
            //spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
            char_name.text = Game.current.player.name;
            health.text = "Health: " + (Game.current.player.currenthealth).ToString() + " / " + (Game.current.player.maxhealth).ToString();
            level_health.text = (Game.current.player.currenthealth).ToString() + " / " + (Game.current.player.maxhealth).ToString();
            l_health = Game.current.player.maxhealth;

            strength.text = "Strength: " + (Game.current.player.strength).ToString();
            level_strength.text = (Game.current.player.strength).ToString();
            l_str = Game.current.player.strength;

            dexterity.text = "Dexterity: " + (Game.current.player.dexterity).ToString();
            level_dexterity.text = (Game.current.player.dexterity).ToString();
            l_dex = Game.current.player.dexterity;

            wisdom.text = "Wisdom: " + (Game.current.player.wisdom).ToString();
            level_wisdom.text = (Game.current.player.wisdom).ToString();
            l_wis = Game.current.player.wisdom;

            piety.text = "Piety: " + (Game.current.player.piety).ToString();
            level_piety.text = (Game.current.player.piety).ToString();
            l_piety = Game.current.player.piety;

            resistance.text = "Resistance: " + (Game.current.player.resistance).ToString();
            level_resistance.text = (Game.current.player.resistance).ToString();
            l_res = Game.current.player.resistance;

            person = Game.current.player;

        }
        //check to see if have 2nd party member
        else if ((c == 1) && (Game.current.party[0] != null))
        {
            points = Game.current.party[0].skillPoints;
            totalpoints = Game.current.party[0].skillPoints;
            spr.enabled = true;
            char_name.text = Game.current.party[0].name;
            char_type = Game.current.party[0].charactertype;

            //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
            if (char_type == "sheep")
            {
                spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "farmer")
            {
                spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "cat")
            {
                spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "drunkard")
            {
                spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
            }
            //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

            health.text = "Health: " + (Game.current.party[0].currenthealth).ToString() + " / " + (Game.current.party[0].maxhealth).ToString();
            level_health.text = (Game.current.party[0].currenthealth).ToString() + " / " + (Game.current.party[0].maxhealth).ToString();

            strength.text = "Strength: " + (Game.current.party[0].strength).ToString();
            level_strength.text = (Game.current.party[0].strength).ToString();

            dexterity.text = "Dexterity: " + (Game.current.party[0].dexterity).ToString();
            level_dexterity.text = (Game.current.party[0].dexterity).ToString();

            wisdom.text = "Wisdom: " + (Game.current.party[0].wisdom).ToString();
            level_wisdom.text = (Game.current.party[0].wisdom).ToString();

            piety.text = "Piety: " + (Game.current.party[0].piety).ToString();
            level_piety.text = (Game.current.party[0].piety).ToString();

            resistance.text = "Resistance: " + (Game.current.party[0].resistance).ToString();
            level_resistance.text = (Game.current.party[0].resistance).ToString();

            l_health = Game.current.party[0].maxhealth;
            l_str = Game.current.party[0].strength;
            l_dex = Game.current.party[0].dexterity;
            l_wis = Game.current.party[0].wisdom;
            l_piety = Game.current.party[0].piety;
            l_res = Game.current.party[0].resistance;

            person = Game.current.party[0];

        }
        //check to see if have 3rd party member
        else if ((c == 2) && (Game.current.party[1] != null))
        {
            points = Game.current.party[1].skillPoints;
            totalpoints = Game.current.party[1].skillPoints;
            char_name.text = Game.current.party[1].name;
            char_type = Game.current.party[1].charactertype;

            spr.enabled = true;
            //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
            if (char_type == "sheep")
            {
                spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "farmer")
            {
                spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "cat")
            {
                spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "drunkard")
            {
                spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
            }
            //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------


            health.text = "Health: " + (Game.current.party[1].currenthealth).ToString() + " / " + (Game.current.party[1].maxhealth).ToString();
            level_health.text = (Game.current.party[1].currenthealth).ToString() + " / " + (Game.current.party[1].maxhealth).ToString();

            strength.text = "Strength: " + (Game.current.party[1].strength).ToString();
            level_strength.text = (Game.current.party[1].strength).ToString();

            dexterity.text = "Dexterity: " + (Game.current.party[1].dexterity).ToString();
            level_dexterity.text = (Game.current.party[1].dexterity).ToString();

            wisdom.text = "Wisdom: " + (Game.current.party[1].wisdom).ToString();
            level_wisdom.text = (Game.current.party[1].wisdom).ToString();

            piety.text = "Piety: " + (Game.current.party[1].piety).ToString();
            level_piety.text = (Game.current.party[1].piety).ToString();

            resistance.text = "Resistance: " + (Game.current.party[1].resistance).ToString();
            level_resistance.text = (Game.current.party[1].resistance).ToString();

            l_health = Game.current.party[1].maxhealth;
            l_str = Game.current.party[1].strength;
            l_dex = Game.current.party[1].dexterity;
            l_wis = Game.current.party[1].wisdom;
            l_piety = Game.current.party[1].piety;
            l_res = Game.current.party[1].resistance;

            person = Game.current.party[1];
        }
        //check to see if have 4th party member
        else if ((c == 3) && (Game.current.party[2] != null))
        {
            points = Game.current.party[2].skillPoints;
            totalpoints = Game.current.party[2].skillPoints;
            char_name.text = Game.current.party[2].name;
            char_type = Game.current.party[2].charactertype;
            spr.enabled = true;
            //---------------------IMPORTANT: Change if statment names if you changed them in Game.cs--------------------------------------------------
            if (char_type == "sheep")
            {
                spr.sprite = Resources.Load("sheep", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "farmer")
            {
                spr.sprite = Resources.Load("farmer", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "cat")
            {
                spr.sprite = Resources.Load("cat", typeof(Sprite)) as Sprite;
            }
            else if (char_type == "drunkard")
            {
                spr.sprite = Resources.Load("drunkard", typeof(Sprite)) as Sprite;
            }
            //---------------------END OF IMPORTANT--------------------------------------------------------------------------------------------------

            health.text = "Health: " + (Game.current.party[2].currenthealth).ToString() + " / " + (Game.current.party[2].maxhealth).ToString();
            level_health.text = (Game.current.party[2].currenthealth).ToString() + " / " + (Game.current.party[2].maxhealth).ToString();

            strength.text = "Strength: " + (Game.current.party[2].strength).ToString();
            level_strength.text = (Game.current.party[2].strength).ToString();

            dexterity.text = "Dexterity: " + (Game.current.party[2].dexterity).ToString();
            level_dexterity.text = (Game.current.party[2].dexterity).ToString();

            wisdom.text = "Wisdom: " + (Game.current.party[2].wisdom).ToString();
            level_wisdom.text = (Game.current.party[2].wisdom).ToString();

            piety.text = "Piety: " + (Game.current.party[2].piety).ToString();
            level_piety.text = (Game.current.party[2].piety).ToString();

            resistance.text = "Resistance: " + (Game.current.party[2].resistance).ToString();
            level_resistance.text = (Game.current.party[2].resistance).ToString();

            l_health = Game.current.party[2].maxhealth;
            l_str = Game.current.party[2].strength;
            l_dex = Game.current.party[2].dexterity;
            l_wis = Game.current.party[2].wisdom;
            l_piety = Game.current.party[2].piety;
            l_res = Game.current.party[2].resistance;

            person = Game.current.party[2];
        }
        //----------------------------End of set up---------------------------------------
        //figure out how many lvls, how many points
        point_Text.text = points.ToString();
        buttonListeners();

    }//End of function

    void buttonListeners()
    {
        h_Plus.onClick.RemoveAllListeners();
        h_Plus.onClick.AddListener(plusH);

        h_Minus.onClick.RemoveAllListeners();
        h_Minus.onClick.AddListener(minusH);


        s_Plus.onClick.RemoveAllListeners();
        s_Plus.onClick.AddListener(plusS);

        s_Minus.onClick.RemoveAllListeners();
        s_Minus.onClick.AddListener(minusS);


        d_Plus.onClick.RemoveAllListeners();
        d_Plus.onClick.AddListener(plusD);

        d_Minus.onClick.RemoveAllListeners();
        d_Minus.onClick.AddListener(minusD);


        w_Plus.onClick.RemoveAllListeners();
        w_Plus.onClick.AddListener(plusW);

        w_Minus.onClick.RemoveAllListeners();
        w_Minus.onClick.AddListener(minusW);


        p_Plus.onClick.RemoveAllListeners();
        p_Plus.onClick.AddListener(plusP);

        p_Minus.onClick.RemoveAllListeners();
        p_Minus.onClick.AddListener(minusP);


        r_Plus.onClick.RemoveAllListeners();
        r_Plus.onClick.AddListener(plusR);

        r_Minus.onClick.RemoveAllListeners();
        r_Minus.onClick.AddListener(minusR);

        commit.onClick.RemoveAllListeners();
        commit.onClick.AddListener(commitPoints);
    }

    void plusH()
    {
        if (points > 0)
        {
            l_health = l_health + 5;
            level_health.text = l_health + "/" + l_health;
            points = points - 1;
            point_Text.text = points.ToString();
        }

    }
    void minusH()
    {
        if ((l_health - 5) < person.maxhealth)
        {
            //do nothing
        }
        else if (points < totalpoints)
        {
            l_health = l_health - 5;
            level_health.text = l_health + "/" + l_health;
            points = points + 1;
            point_Text.text = points.ToString();
        }
    }

    void plusS()
    {
        if (points > 0)
        {
            l_str = l_str + 1;
            level_strength.text = l_str.ToString();
            points = points - 1;
            point_Text.text = points.ToString();
        }
    }
    void minusS()
    {
        //check to see if removing already commited points
        if ((l_str - 1) < person.strength)
        {
            //do nothing
        }
        else if (points < totalpoints)
        {
            l_str = l_str - 1;
            level_strength.text = l_str.ToString();
            points = points + 1;
            point_Text.text = points.ToString();
        }
    }

    void plusD()
    {
        if (points > 0)
        {
            l_dex = l_dex + 1;
            level_dexterity.text = l_dex.ToString();
            points = points - 1;
            point_Text.text = points.ToString();
        }
    }
    void minusD()
    {
        //check to see if removing already commited points
        if ((l_dex - 1) < person.dexterity)
        {
            //do nothing
        }
        else if (points < totalpoints)
        {
            l_dex = l_dex - 1;
            level_dexterity.text = l_dex.ToString();
            points = points + 1;
            point_Text.text = points.ToString();
        }
    }

    void plusW()
    {
        if (points > 0)
        {
            l_wis = l_wis + 1;
            level_wisdom.text = l_wis.ToString();
            points = points - 1;
            point_Text.text = points.ToString();
        }
    }
    void minusW()
    {
        //check to see if removing already commited points
        if ((l_wis - 1) < person.wisdom)
        {
            //do nothing
        }
        else if (points < totalpoints)
        {
            l_wis = l_wis - 1;
            level_wisdom.text = l_wis.ToString();
            points = points + 1;
            point_Text.text = points.ToString();
        }
    }

    void plusP()
    {
        if (points > 0)
        {
            l_piety = l_piety + 1;
            level_piety.text = l_piety.ToString();
            points = points - 1;
            point_Text.text = points.ToString();
        }
    }
    void minusP()
    {
        //check to see if removing already commited points
        if ((l_piety - 1) < person.piety)
        {
            //do nothing
        }
        else if (points < totalpoints)
        {
            l_piety = l_piety - 1;
            level_piety.text = l_piety.ToString();
            points = points + 1;
            point_Text.text = points.ToString();
        }
    }

    void plusR()
    {
        if (points > 0)
        {
            l_res = l_res + 1;
            level_resistance.text = l_res.ToString();
            points = points - 1;
            point_Text.text = points.ToString();
        }
    }
    void minusR()
    {
        //check to see if removing already commited points
        if ((l_res - 1) < person.resistance)
        {
            //do nothing
        }
        else if (points < totalpoints)
        {
            l_res = l_res - 1;
            level_resistance.text = l_res.ToString();
            points = points + 1;
            point_Text.text = points.ToString();
        }
    }

    void commitPoints()
    {

        //can level lvl up
        person.maxhealth = l_health;
        person.currenthealth = l_health;
        person.strength = l_str;
        person.dexterity = l_dex;
        person.wisdom = l_wis;
        person.piety = l_piety;
        person.resistance = l_res;
        ui_manager.hideLevelUpPanel();
        switch (character)
        {
            case 0:
                Game.current.player.skillPoints = points;
                break;
            case 1:
                Game.current.party[0].skillPoints = points;
                break;
            case 2:
                Game.current.party[1].skillPoints = points;
                break;
            case 3:
                Game.current.party[2].skillPoints = points;
                break;
        }
        totalpoints = points;
    }
}
