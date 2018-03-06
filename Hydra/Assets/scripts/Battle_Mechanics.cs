using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Mechanics : MonoBehaviour
{

    public Battle_UI uiHandler;
    public postBattleReset leaveBattleScene;
    bool buttonClicked;
    private bool battleOver;
    private bool playerWon;
    private bool playerFled;
    private bool charSelected;
    private Character selected;
    private bool dead;

    //Characters-------------------------------
    private Character hero;
    private Character party1;
    private Character party2;
    private Character party3;


    public Text heroText;
    public Text party1Text;
    public Text party2Text;
    public Text party3Text;

    public Image heroSprite;
    public Image party1Sprite;
    public Image party2Sprite;
    public Image party3Sprite;

    private bool heroDead;
    private bool party1Dead;
    private bool party2Dead;
    private bool party3Dead;


    private Character b;
    public Text btext;
    public Image bSprite;
    private bool bDead;

    private Character enemy1;
    private Character enemy2;
    private Character enemy3;
    private Character enemy4;

    public Text enemy1Text;
    public Text enemy2Text;
    public Text enemy3Text;
    public Text enemy4Text;

    public Image enemy1Sprite;
    public Image enemy2Sprite;
    public Image enemy3Sprite;
    public Image enemy4Sprite;

    private bool enemy1Dead;
    private bool enemy2Dead;
    private bool enemy3Dead;
    private bool enemy4Dead;

    //----------LOGIC: based on D&D, turn order based on dexterity stat---------
    //List to store characters, to then sort by dext largest to smallest
    private List<Character> orderedChars;

    //To keep track of whose turn it is-------------------------------
    //max number of characters in play is 8 (4 player, 4 enemy)
    private Character currentTurn;
    private Character temp;

    //update visual turn tracker----------------
    public Image turn_current;
    public Image turn_1;
    public Image turn_2;
    public Image turn_3;
    public Image turn_4;
    public Image turn_5;
    public Image turn_6;
    public Image turn_7;

    //buttons to get player input---------------
    public Button melee1;
    public Text melee1chance;
    public Button melee2;
    public Text melee2chance;
    public Button melee3;
    public Text melee3chance;

    public Button magic1;
    public Text magic1chance;
    public Button magic2;
    public Text magic2chance;
    public Button magic3;
    public Text magic3chance;

    public Button heal1;
    public Text heal1amount;
    public Button heal2;
    public Text heal2amount;
    public Button heal3;
    public Text heal3amount;

    public Button intimidate1;
    public Text intimidate1chance;
    public Button intimidate2;
    public Text intimidate2chance;
    public Button intimidate3;
    public Text intimidate3chance;

    public Button charm1;
    public Text charm1chance;
    public Button charm2;
    public Text charm2chance;
    public Button charm3;
    public Text charm3chance;

    public Button bribe1;
    public Text bribe1chance;
    public Button bribe2;
    public Text bribe2chance;
    public Button bribe3;
    public Text bribe3chance;

    public Button option1;
    public Text option1text;
    public Button option2;
    public Text option2text;
    public Button option3;
    public Text option3text;
    public Button option4;
    public Text option4text;

    public Button runaway;
    public Text runawaychance;

    //Status Text to update when Turn is taken to inform player
    public Text enemyDamageText;
    public Text enemyHealText;
    public Text enemyOtherText;
    public Text playerDamageText;
    public Text playerHealText;
    public Text playerOtherText;
    public Text battleOverText;

    // Use this for initialization
    void Start()
    {
        battleOver = false;
        playerWon = false;
        playerFled = false;
        //init party , boss, and enemy party to null
        party1 = null;
        party2 = null;
        party3 = null;
        b = null;
        enemy1 = null;
        enemy2 = null;
        enemy3 = null;
        enemy4 = null;
        orderedChars = new List<Character>();


        //init hero
        hero = new Character(Game.current.player);
        orderedChars.Add(hero);
        heroDead = false;


        //check for player party members
        if (Game.current.party[0] != null)
        {
            party1 = new Character(Game.current.party[0]);
            orderedChars.Add(party1);
            party1Dead = false;

        }

        if (Game.current.party[1] != null)
        {
            party2 = new Character(Game.current.party[1]);
            orderedChars.Add(party2);
            party2Dead = false;
        }

        if (Game.current.party[2] != null)
        {
            party3 = new Character(Game.current.party[2]);
            orderedChars.Add(party3);
            party3Dead = false;
        }

        //check for boss
        if (Game.current.boss != null)
        {
            b = new Character(Game.current.boss);
            orderedChars.Add(b);
            bDead = false;
        }
        if (Game.current.enemyParty[0] != null)
        {
            enemy1 = new Character(Game.current.enemyParty[0]);
            orderedChars.Add(enemy1);
            enemy1Dead = false;
        }
        if (Game.current.enemyParty[1] != null)
        {
            enemy2 = new Character(Game.current.enemyParty[1]);
            orderedChars.Add(enemy2);
            enemy2Dead = false;
        }
        if (Game.current.enemyParty[2] != null)
        {
            enemy3 = new Character(Game.current.enemyParty[2]);
            orderedChars.Add(enemy3);
            enemy3Dead = false;
        }
        if (Game.current.enemyParty[3] != null)
        {
            enemy4 = new Character(Game.current.enemyParty[3]);
            orderedChars.Add(enemy4);
            enemy4Dead = false;
        }
        //figure out who goes first, seconds.....
        Character key;
        int i;
        int size = orderedChars.Count;
        for (int j = 1; j < size; j++)
        {
            key = orderedChars[j];
            i = j - 1;
            while (i >= 0 && orderedChars[i].dexterity < key.dexterity)
            {
                orderedChars[i + 1] = orderedChars[i];
                i = i - 1;
            }
            orderedChars[i + 1] = key;
        }

        //---------------------------------------Turn Order display-----------------------------------

        //load sprites for turn order
        loadSprites();

        //-----------------------------------Turn order displayed-----------------------------------------
        //Battle...START!
        StartCoroutine(battle());

    }

    //coroutine so it can be paused for player input
    IEnumerator battle()
    {
        //loop battle until all enemys die or all players die
        while (battleOver == false)
        {
            Debug.Log("Battle Phase");
            dead = false;

            battleOverText.enabled = false;
            //is it the players turn or not---------------------------
            if (currentTurn == hero || currentTurn == party1 || currentTurn == party2 || currentTurn == party3)
            {
                Debug.Log("PlayerTurn");
                playerTurn(currentTurn);

                //wait for player to click button
                while (buttonClicked == false)
                {
                    yield return null;

                }
                //Debug.Log("did player turn happen?");
                yield return new WaitForSeconds(1);
                Debug.Log("selected is before is dead " + selected.name);
                dead = isDead(selected);
                checkbattleOver(1);
            }

            //enemy turn-----------------------------------------
            else
            {
                Debug.Log("EnemyTurn");
                enemyTurn(currentTurn);
                Debug.Log("outofenemyturn");
                //pause 2 seconds for enemy turn
                yield return new WaitForSeconds(3);
                Debug.Log("selected is before is dead " + selected.name);
                dead = isDead(selected);
                checkbattleOver(2);
                Debug.Log("outofcheckbattleOver");
            }

            //turn is over, now check to see if selected is dead and needs to be removed
            removeDead(dead);



            //------turn has been taken, update turn order-----------------
            temp = currentTurn;

            //remove currentTurn char from list
            //the rest of the chars should now shift up in idx [1-0>0, 2->1....]
            orderedChars.RemoveAt(0);

            //add currentTurn char to end of list
            orderedChars.Add(temp);

            //update sprites
            loadSprites();

            //update currentTurn
            currentTurn = orderedChars[0];

            //----------------------------- turn order has been updated-----
            playerHealText.enabled = false;
            playerDamageText.enabled = false;
            playerOtherText.enabled = false;
            enemyDamageText.enabled = false;
            enemyHealText.enabled = false;
            enemyOtherText.enabled = false;
        }
        Debug.Log("Battle OVER");
        yield return new WaitForSeconds(3);
        leaveBattle(playerWon, playerFled);
        yield return new WaitForSeconds(3);
        leaveBattleScene.leaveBattle();

    }

    //-----WIP ------------------------------------------
    public void enemyTurn(Character c)
    {
        int damage;
        int chance;
        int success;
        uiHandler.hideBattleUI();
        //enemy does stuff...

        //choose who to attack
        chooseTarget();
        Debug.Log("selected is again " + selected.name);

        if (b != null)
        {
            //if the character is a boss
            if (c.name == b.name)
            {
                //do specific boss stuff
                if (Game.current.unicorn.name == c.name)
                {
                    //Unicorn will either (0) taunt (wisdom -1), (1)Magic Attack, (2) or heal but only under half health
                    damage = c.wisdom;
                    chance = c.dexterity;
                    int piety = c.piety;

                    int rand = Random.Range(0, 3);
                    if (rand == 0)
                    {
                        //taunt
                        if (selected.wisdom != 0)
                        {
                            selected.wisdom = selected.wisdom - 1;
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " taunted " + selected.name + " for -1 wisdom";
                        }
                        else
                        {
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " failed to taunt " + selected.name + " because their wisdom is 0";
                        }


                    }
                    else if (rand == 1)
                    {
                        //magic attack
                        //small attack
                        chance = chance * 15;
                        success = Random.Range(0, 100);
                        if (success <= chance)
                        {
                            selected.currenthealth = selected.currenthealth - damage;
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " did " + damage + " damage to " + selected.name;
                        }
                        else
                        {
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " Missed " + selected.name;
                        }
                    }
                    else
                    {
                        //heal
                        if (c.currenthealth < 25)
                        {
                            c.currenthealth = c.currenthealth + piety;
                            enemyHealText.enabled = true;
                            enemyHealText.text = c.name + " healed for " + piety;
                        }
                        else
                        {
                            selected.currenthealth = selected.currenthealth - 1;
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " insulted " + selected.name + " for 1 damage";
                        }
                    }
                }
                else if (Game.current.goblin.name == c.name)
                {
                    damage = c.strength;
                    chance = c.dexterity;

                    //will the heads agree or not
                    int rand1 = Random.Range(0, 2);
                    int rand2 = Random.Range(0, 2);

                    if (rand1 == rand2)
                    {
                        //they agree!
                        int rand = Random.Range(0, 2);
                        if (rand == 0)
                        {
                            enemyOtherText.enabled = true;
                            enemyOtherText.text = "The goblin twins agree to attack this time";
                            //attack
                            chance = chance * 25;
                            success = Random.Range(0, 100);
                            if (success <= chance)
                            {
                                selected.currenthealth = selected.currenthealth - damage;
                                enemyDamageText.enabled = true;
                                enemyDamageText.text = c.name + " did " + damage + " damage to " + selected.name;
                            }
                            else
                            {
                                enemyDamageText.enabled = true;
                                enemyDamageText.text = c.name + " Missed " + selected.name;
                            }
                        }
                        else
                        {
                            //defend (defend and heal for 5)
                            enemyOtherText.enabled = true;
                            enemyOtherText.text = "The goblin twins agree to defend this time";
                            c.currenthealth = c.currenthealth + 5;
                            enemyHealText.enabled = true;
                            enemyHealText.text = c.name + " defended and healed for 5";

                        }

                    }
                    else
                    {
                        //they dont agree
                        enemyOtherText.enabled = true;
                        enemyOtherText.text = "The goblin twins do NOT agree this time";

                        //attack
                        chance = 75;
                        damage = 2;
                        success = Random.Range(0, 100);
                        if (success <= chance)
                        {
                            selected.currenthealth = selected.currenthealth - damage;
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " did " + damage + " damage to " + selected.name;
                        }
                        else
                        {
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " Missed " + selected.name;
                        }
                        //defend
                        success = Random.Range(0, 100);
                        if (success <= chance)
                        {
                            c.currenthealth = c.currenthealth + 2;
                            enemyHealText.enabled = true;
                            enemyHealText.text = c.name + " defended and healed for 1";
                        }
                        else
                        {
                            enemyHealText.enabled = true;
                            enemyHealText.text = c.name + " failed to defend.";
                        }
                    }

                }
                else //ink------------------------WIP-------------Currently just attacks
                {
                    damage = c.strength;
                    chance = c.dexterity;

                    int rand = Random.Range(0, 2);

                    if (rand == 0)
                    {
                        //small attack
                        chance = chance * 20;
                        success = Random.Range(0, 100);
                        if (success <= chance)
                        {
                            selected.currenthealth = selected.currenthealth - damage;
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " did " + damage + " damage to " + selected.name;
                        }
                        else
                        {
                            enemyDamageText.enabled = true;
                            enemyDamageText.text = c.name + " Missed " + selected.name;
                        }
                    }
                    else
                    {
                        enemyOtherText.enabled = true;
                        enemyOtherText.text = "ink blot does nothing";
                    }
                }
            }
        }
        if (c != b) //not a boss
        {
            damage = c.strength;
            chance = c.dexterity;

            int rand = Random.Range(0, 2);

            if (rand == 0)
            {
                //small attack
                chance = chance * 20;
                success = Random.Range(0, 100);
                if (success <= chance)
                {
                    selected.currenthealth = selected.currenthealth - damage;
                    enemyDamageText.enabled = true;
                    enemyDamageText.text = c.name + " did " + damage + " damage to " + selected.name;
                }
                else
                {
                    enemyDamageText.enabled = true;
                    enemyDamageText.text = c.name + " Missed " + selected.name;
                }
            }
            else
            {
                //rand == 1, big attack
                damage = damage * 2;
                chance = chance * 5;
                success = Random.Range(0, 100);
                if (success <= chance)
                {
                    selected.currenthealth = selected.currenthealth - damage;
                    enemyDamageText.enabled = true;
                    enemyDamageText.text = c.name + " did " + damage + " damage to " + selected.name;
                }
                else
                {
                    enemyDamageText.enabled = true;
                    enemyDamageText.text = c.name + " Missed " + selected.name;
                }
            }


        }
    }

    /*  playerTurn(Character c)
     *   Input: The Character that is currently making a move 
     *   
     *   Player is shown the UI panel and can select from a multitude of options 
     *   (damage,heal,talk,runaway), some with sub menus
     *   
     *   This function is in charge of:
     *              displaying the Battle UI panel
     *              setting buttonClicked to false
     *              Calling choice() : 
     *                         which adds listerners to the buttons for player click
     */

    void playerTurn(Character c)
    {
        Debug.Log("In player Turn");
        //Debug.Log(c.name);
        updateChanceTexts(c);

        uiHandler.showBattleUI();
        buttonClicked = false;
        choice();

    }

    //Updates the text fields for the chance and amounts for player character c
    void updateChanceTexts(Character c)
    {
        //Melee Amount = Strength
        //Melee Chance = Strength + Dex ?
        float dex = c.dexterity;
        float str = c.strength;
        float wis = c.wisdom;
        float pie = c.piety;

        float damage = str;
        float percentChance = (dex / 5) * 100;
        melee1chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";

        damage = str * 2;
        percentChance = (dex / 10) * 100;
        melee2chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";

        damage = str * 5;
        percentChance = (dex / 25) * 100;
        melee3chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";


        //Magic Amount = Wisdom
        //Magic Chance = Wisdom + dex?

        damage = wis;
        percentChance = (dex / 5) * 100;
        magic1chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";

        damage = wis * 2;
        percentChance = (dex / 10) * 100;
        magic2chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";

        damage = wis * 5;
        percentChance = (dex / 25) * 100;
        magic3chance.text = "Damage: " + (damage) + " Chance: " + (percentChance) + "%";


        //Heal Amount = Piety
        //chance to crit: wisdom

        damage = pie;
        heal1amount.text = "Amount: " + (damage);

        damage = pie;
        heal2amount.text = "Amount: " + (damage);

        damage = Mathf.Floor(pie / 4) * 2;
        heal3amount.text = "Amount: " + (damage);


        //Intimidate = Strength based
        percentChance = (str / 5) * 100;
        intimidate1chance.text = " Chance: " + (percentChance) + "%";

        percentChance = (str / 10) * 100;
        intimidate2chance.text = " Chance: " + (percentChance) + "%";

        percentChance = (dex / 25) * 100;
        intimidate3chance.text = " Chance: " + (percentChance) + "%";

        //Charm = Wisdom based
        percentChance = (wis / 5) * 100;
        charm1chance.text = " Chance: " + (percentChance) + "%";

        percentChance = (wis / 10) * 100;
        charm2chance.text = " Chance: " + (percentChance) + "%";

        percentChance = (wis / 25) * 100;
        charm3chance.text = " Chance: " + (percentChance) + "%";


        //Bribe = Dex based
        percentChance = (dex / 5) * 100;
        bribe1chance.text = " Chance: " + (percentChance) + "%";

        percentChance = (dex / 10) * 100;
        bribe2chance.text = " Chance: " + (percentChance) + "%";

        percentChance = (dex / 25) * 100;
        bribe3chance.text = " Chance: " + (percentChance) + "%";


        //Is it boss battle? If yes player CAN'T run
        //Dex based?

        //not a boss fight player CAN run
        if (b == null)
        {
            runaway.gameObject.SetActive(true);
            percentChance = (dex / 20) * 100;
            runawaychance.text = " Chance: " + (percentChance) + "%";
        }
        else
        {
            runaway.gameObject.SetActive(false);
            runawaychance.text = " No Chance of Escape! ";
        }

    }


    //Adds listeners to buttons for onClick()
    void choice()
    {
        //Debug.Log("choice");
        melee1.onClick.RemoveAllListeners();
        melee1.onClick.AddListener(delegate { StartCoroutine(melee(1)); });

        melee2.onClick.RemoveAllListeners();
        melee2.onClick.AddListener(delegate { StartCoroutine(melee(2)); });

        melee3.onClick.RemoveAllListeners();
        melee3.onClick.AddListener(delegate { StartCoroutine(melee(3)); });


        magic1.onClick.RemoveAllListeners();
        magic1.onClick.AddListener(delegate { StartCoroutine(magic(1)); });

        magic2.onClick.RemoveAllListeners();
        magic2.onClick.AddListener(delegate { StartCoroutine(magic(2)); });

        magic3.onClick.RemoveAllListeners();
        magic3.onClick.AddListener(delegate { StartCoroutine(magic(3)); });


        heal1.onClick.RemoveAllListeners();
        heal1.onClick.AddListener(delegate { StartCoroutine(heal(1)); });

        heal2.onClick.RemoveAllListeners();
        heal2.onClick.AddListener(delegate { StartCoroutine(heal(2)); });

        heal3.onClick.RemoveAllListeners();
        heal3.onClick.AddListener(delegate { StartCoroutine(heal(3)); });


        runaway.onClick.RemoveAllListeners();
        runaway.onClick.AddListener(attemptRunaway);


        intimidate1.onClick.RemoveAllListeners();
        intimidate1.onClick.AddListener(delegate { StartCoroutine(intimidate(1)); });

        intimidate2.onClick.RemoveAllListeners();
        intimidate2.onClick.AddListener(delegate { StartCoroutine(intimidate(2)); });

        intimidate3.onClick.RemoveAllListeners();
        intimidate3.onClick.AddListener(delegate { StartCoroutine(intimidate(3)); });


        charm1.onClick.RemoveAllListeners();
        charm1.onClick.AddListener(delegate { StartCoroutine(charm(1)); });

        charm2.onClick.RemoveAllListeners();
        charm2.onClick.AddListener(delegate { StartCoroutine(charm(2)); });

        charm3.onClick.RemoveAllListeners();
        charm3.onClick.AddListener(delegate { StartCoroutine(charm(3)); });


        bribe1.onClick.RemoveAllListeners();
        bribe1.onClick.AddListener(delegate { StartCoroutine(bribe(1)); });

        bribe2.onClick.RemoveAllListeners();
        bribe2.onClick.AddListener(delegate { StartCoroutine(bribe(2)); });

        bribe3.onClick.RemoveAllListeners();
        bribe3.onClick.AddListener(delegate { StartCoroutine(bribe(3)); });

    }

    IEnumerator melee(int a)
    {
        int dex = currentTurn.dexterity;
        int str = currentTurn.strength;

        if (a == 1)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = str;
            int percentChance = dex * 20;
            int success = Random.Range(0, 100);
            Debug.Log(success);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        b.currenthealth = healthCalc(b.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + b.name;

                    }
                }
                if (enemy1 != null)
                {
                    Debug.Log("0");
                    if (enemy1 == selected)
                    {
                        enemy1.currenthealth = healthCalc(enemy1.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy1.name;
                    }
                }
                if (enemy2 != null)
                {
                    Debug.Log("1");
                    if (enemy2 == selected)
                    {
                        Debug.Log("2");

                        enemy2.currenthealth = healthCalc(enemy2.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy2.name;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.currenthealth = healthCalc(enemy3.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy3.name;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.currenthealth = healthCalc(enemy4.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy4.name;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("melee1");
        }
        else if (a == 2)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = str * 2;
            int percentChance = dex * 10;
            Debug.Log(percentChance);
            int success = Random.Range(0, 100);
            Debug.Log(success);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        b.currenthealth = healthCalc(b.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + b.name;

                    }
                }
                if (enemy1 != null)
                {
                    Debug.Log("0");
                    if (enemy1 == selected)
                    {
                        enemy1.currenthealth = healthCalc(enemy1.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy1.name;
                    }
                }
                if (enemy2 != null)
                {
                    Debug.Log("1");
                    if (enemy2 == selected)
                    {
                        Debug.Log("2");

                        enemy2.currenthealth = healthCalc(enemy2.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy2.name;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.currenthealth = healthCalc(enemy3.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy3.name;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.currenthealth = healthCalc(enemy4.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy4.name;
                    }
                }
            }
            else
            {
                //no dmg done
                Debug.Log("MISS " + percentChance + " % , success " + success);

            }
            buttonClicked = true;
            Debug.Log("melee2");
        }
        else//a = 3
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }
            int damage = str * 5;
            int percentChance = dex * 4;
            int success = Random.Range(0, 100);
            Debug.Log(success);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        b.currenthealth = healthCalc(b.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + b.name;

                    }
                }
                if (enemy1 != null)
                {
                    Debug.Log("0");
                    if (enemy1 == selected)
                    {
                        enemy1.currenthealth = healthCalc(enemy1.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy1.name;
                    }
                }
                if (enemy2 != null)
                {
                    Debug.Log("1");
                    if (enemy2 == selected)
                    {
                        Debug.Log("2");

                        enemy2.currenthealth = healthCalc(enemy2.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy2.name;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.currenthealth = healthCalc(enemy3.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy3.name;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.currenthealth = healthCalc(enemy4.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy4.name;
                    }
                }
            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("melee3");
        }

    }

    //magic
    IEnumerator magic(int a)
    {
        int dex = currentTurn.dexterity;
        //int str = currentTurn.strength;
        int wis = currentTurn.wisdom;
        // int pie = currentTurn.piety;


        if (a == 1)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = wis;
            int percentChance = dex * 20;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        b.currenthealth = healthCalc(b.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + b.name;

                    }
                }
                if (enemy1 != null)
                {
                    Debug.Log("0");
                    if (enemy1 == selected)
                    {
                        enemy1.currenthealth = healthCalc(enemy1.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy1.name;
                    }
                }
                if (enemy2 != null)
                {
                    Debug.Log("1");
                    if (enemy2 == selected)
                    {
                        Debug.Log("2");

                        enemy2.currenthealth = healthCalc(enemy2.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy2.name;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.currenthealth = healthCalc(enemy3.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy3.name;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.currenthealth = healthCalc(enemy4.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy4.name;
                    }
                }
            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("magic1");
        }
        else if (a == 2)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = wis * 2;
            int percentChance = dex * 10;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        b.currenthealth = healthCalc(b.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + b.name;

                    }
                }
                if (enemy1 != null)
                {
                    Debug.Log("0");
                    if (enemy1 == selected)
                    {
                        enemy1.currenthealth = healthCalc(enemy1.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy1.name;
                    }
                }
                if (enemy2 != null)
                {
                    Debug.Log("1");
                    if (enemy2 == selected)
                    {
                        Debug.Log("2");

                        enemy2.currenthealth = healthCalc(enemy2.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy2.name;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.currenthealth = healthCalc(enemy3.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy3.name;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.currenthealth = healthCalc(enemy4.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy4.name;
                    }
                }
            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("magic2");
        }
        else//a = 3
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }
            int damage = wis * 5;
            int percentChance = dex * 4;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        b.currenthealth = healthCalc(b.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + b.name;

                    }
                }
                if (enemy1 != null)
                {
                    Debug.Log("0");
                    if (enemy1 == selected)
                    {
                        enemy1.currenthealth = healthCalc(enemy1.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy1.name;
                    }
                }
                if (enemy2 != null)
                {
                    Debug.Log("1");
                    if (enemy2 == selected)
                    {
                        Debug.Log("2");

                        enemy2.currenthealth = healthCalc(enemy2.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy2.name;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.currenthealth = healthCalc(enemy3.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy3.name;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.currenthealth = healthCalc(enemy4.currenthealth, damage);
                        playerDamageText.enabled = true;
                        playerDamageText.text = currentTurn.name + " did " + damage + " damage to " + enemy4.name;
                    }
                }
            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("magic3");
        }

    }

    //heal
    //------------Check for bugs
    IEnumerator heal(int a)
    {
        int pie = currentTurn.piety;

        if (a == 1)
        {
            Debug.Log("healself...");
            int heal = pie;
            //figure out WHO is current turn
            if (hero.name == currentTurn.name)
            {
                if ((hero.currenthealth + heal) > hero.maxhealth)
                {
                    hero.currenthealth = hero.maxhealth;
                    playerHealText.enabled = true;
                    playerHealText.text = currentTurn.name + " is at max health";
                }
                else
                {
                    hero.currenthealth = hero.currenthealth + heal;
                    playerHealText.enabled = true;
                    playerHealText.text = currentTurn.name + " healed for " + heal;
                }

            }

            if (party1 != null)
            {
                if (party1.name == currentTurn.name)
                {
                    if ((party1.currenthealth + heal) > party1.maxhealth)
                    {
                        party1.currenthealth = party1.maxhealth;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " is at max health";

                    }
                    else
                    {
                        party1.currenthealth = party1.currenthealth + heal;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " healed for " + heal;
                    }

                }
            }
            if (party2 != null)
            {
                if (party2.name == currentTurn.name)
                {
                    if ((party2.currenthealth + heal) > party2.maxhealth)
                    {
                        party2.currenthealth = party2.maxhealth;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " is at max health";
                    }
                    else
                    {
                        party2.currenthealth = party2.currenthealth + heal;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " healed for " + heal;
                    }

                }
            }
            if (party3 != null)
            {
                if (party3.name == currentTurn.name)
                {
                    if ((party3.currenthealth + heal) > party3.maxhealth)
                    {
                        party3.currenthealth = party3.maxhealth;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " is at max health";
                    }
                    else
                    {
                        party3.currenthealth = party3.currenthealth + heal;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " healed for " + heal;
                    }

                }
            }
            buttonClicked = true;
            Debug.Log("healself");
        }
        //something wrong in heal ally------------------------------------------------------------!!!!!!
        else if (a == 2)
        {
            int heal = pie;
            //have player select ally
            playerSelect(1);
            while (charSelected == false)
            {
                yield return null;
            }
            //figure out WHO is selected
            if (hero == selected)
            {
                if (hero.maxhealth < (hero.currenthealth + heal))
                {
                    hero.currenthealth = hero.maxhealth;
                    playerHealText.enabled = true;
                    playerHealText.text = hero.name + " is at max health";
                }
                else
                {
                    hero.currenthealth = hero.currenthealth + heal;
                    playerHealText.enabled = true;
                    playerHealText.text = currentTurn.name + " healed " + hero.name + "for" + heal;
                }

            }

            if (party1 != null)
            {
                if (party1 == selected)
                {
                    if (party1.maxhealth < (party1.currenthealth + heal))
                    {
                        party1.currenthealth = party1.maxhealth;
                        playerHealText.enabled = true;
                        playerHealText.text = party1.name + " is at max health";
                    }
                    else
                    {
                        party1.currenthealth = party1.currenthealth + heal;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " healed " + party1.name + "for" + heal;
                    }

                }
            }
            if (party2 != null)
            {
                if (party2 == selected)
                {
                    if (party2.maxhealth < (party2.currenthealth + heal))
                    {
                        party2.currenthealth = party2.maxhealth;
                        playerHealText.enabled = true;
                        playerHealText.text = party2.name + " is at max health";
                    }
                    else
                    {
                        party2.currenthealth = party2.currenthealth + heal;
                        playerHealText.enabled = true;
                        playerHealText.text = currentTurn.name + " healed " + party2.name + "for" + heal;
                    }
                }
            }
            if (party3 != null)
            {
                if (party3.maxhealth < (party3.currenthealth + heal))
                {
                    party3.currenthealth = party3.maxhealth;
                    playerHealText.enabled = true;
                    playerHealText.text = party3.name + " is at max health";
                }
                else
                {
                    party3.currenthealth = party3.currenthealth + heal;
                    playerHealText.enabled = true;
                    playerHealText.text = currentTurn.name + " healed " + party3.name + "for" + heal;
                }
            }
            buttonClicked = true;
            Debug.Log("healally");
        }
        else//a = 3
        {

            int heal = (int)(Mathf.Floor(pie / 4) * 2);
            playerHealText.enabled = true;
            playerHealText.text = currentTurn.name + " healed each party member for" + heal;

            if (hero.maxhealth < (hero.currenthealth + heal))
            {
                hero.currenthealth = hero.maxhealth;
            }
            else
            {
                hero.currenthealth = hero.currenthealth + heal;
            }

            if (party1 != null)
            {
                if (party1.maxhealth < (party1.currenthealth + heal))
                {
                    party1.currenthealth = party1.maxhealth;
                }
                else
                {
                    party1.currenthealth = party1.currenthealth + heal;
                }

            }
            if (party2 != null)
            {
                if (party2.maxhealth < (party2.currenthealth + heal))
                {
                    party2.currenthealth = party2.maxhealth;
                }
                else
                {
                    party2.currenthealth = party2.currenthealth + heal;
                }
            }
            if (party3 != null)
            {
                if (party3.maxhealth < (party3.currenthealth + heal))
                {
                    party3.currenthealth = party3.maxhealth;
                }
                else
                {
                    party3.currenthealth = party3.currenthealth + heal;
                }
            }
            buttonClicked = true;
            Debug.Log("healgroup");
        }

    }

    //intimidate
    //---------------Check for bugs
    IEnumerator intimidate(int a)
    {
        //lower enemy str
        int str = currentTurn.strength;

        if (a == 1)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 1;
            int percentChance = str * 20;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("Strength was" + b.strength);
                        b.strength = b.strength - damage;
                        Debug.Log("Strength is now" + b.strength);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " strength by " + damage;

                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.strength = enemy1.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " strength by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.strength = enemy2.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " strength by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.strength = enemy3.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " strength by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.strength = enemy4.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " strength by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("intimidate1");
        }
        else if (a == 2)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 2;
            int percentChance = str * 10;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("Strength was" + b.strength);
                        b.strength = b.strength - damage;
                        Debug.Log("Strength is now" + b.strength);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " strength by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.strength = enemy1.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " strength by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.strength = enemy2.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " strength by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.strength = enemy3.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " strength by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.strength = enemy4.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " strength by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("intimidate2");
        }
        else//a = 3
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 3;
            int percentChance = str * 4;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("Strength was" + b.strength);
                        b.strength = b.strength - damage;
                        Debug.Log("Strength is now" + b.strength);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " strength by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.strength = enemy1.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " strength by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.strength = enemy2.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " strength by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.strength = enemy3.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " strength by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.strength = enemy4.strength - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " strength by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("intimidate3");
        }

    }

    //charm
    //---------------Check for bugs
    IEnumerator charm(int a)
    {
        //lower enemy wis
        int wis = currentTurn.wisdom;

        if (a == 1)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 1;
            int percentChance = wis * 20;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("Wisdom was" + b.wisdom);
                        b.wisdom = b.wisdom - damage;
                        Debug.Log("Wisdom is now" + b.wisdom);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " wisdom by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.wisdom = enemy1.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " wisdom by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.wisdom = enemy2.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " wisdom by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.wisdom = enemy3.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " wisdom by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.wisdom = enemy4.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " wisdom by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("charm1");
        }
        else if (a == 2)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 2;
            int percentChance = wis * 10;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("Wisdom was" + b.wisdom);
                        b.wisdom = b.wisdom - damage;
                        Debug.Log("Wisdom is now" + b.wisdom);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " wisdom by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.wisdom = enemy1.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " wisdom by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.wisdom = enemy2.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " wisdom by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.wisdom = enemy3.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " wisdom by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.wisdom = enemy4.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " wisdom by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("charm2");
        }
        else//a = 3
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 3;
            int percentChance = wis * 4;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("Wisdom was" + b.wisdom);
                        b.wisdom = b.wisdom - damage;
                        Debug.Log("Wisdom is now" + b.wisdom);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " wisdom by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.wisdom = enemy1.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " wisdom by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.wisdom = enemy2.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " wisdom by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.wisdom = enemy3.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " wisdom by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.wisdom = enemy4.wisdom - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " wisdom by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("charm3");
        }

    }

    //bribe
    //----------------------
    IEnumerator bribe(int a)
    {
        //lower enemy dex
        //does NOT effect turn order....
        int dex = currentTurn.dexterity;

        if (a == 1)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 1;
            int percentChance = dex * 20;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("dexterity was" + b.dexterity);
                        b.dexterity = b.dexterity - damage;
                        Debug.Log("dexterity is now" + b.dexterity);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " dexterity by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.dexterity = enemy1.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " dexterity by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.dexterity = enemy2.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " dexterity by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.dexterity = enemy3.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " dexterity by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.dexterity = enemy4.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " dexterity by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("bribe1");
        }
        else if (a == 2)
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 2;
            int percentChance = dex * 10;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("dexterity was" + b.dexterity);
                        b.dexterity = b.dexterity - damage;
                        Debug.Log("dexterity is now" + b.dexterity);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " dexterity by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.dexterity = enemy1.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " dexterity by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.dexterity = enemy2.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " dexterity by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.dexterity = enemy3.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " dexterity by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.dexterity = enemy4.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " dexterity by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("bribe2");
        }
        else//a = 3
        {
            //have player select enemy
            playerSelect(2);
            while (charSelected == false)
            {
                yield return null;
            }

            int damage = 3;
            int percentChance = dex * 4;
            int success = Random.Range(0, 100);

            //HIT!
            if (success <= percentChance)
            {
                Debug.Log("hit");
                //figure out who was hit

                //was it the boss?
                if (b != null)
                {
                    if (b == selected)
                    {
                        Debug.Log("dexterity was" + b.dexterity);
                        b.dexterity = b.dexterity - damage;
                        Debug.Log("dexterity is now" + b.dexterity);
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + b.name + " dexterity by " + damage;
                    }
                }
                if (enemy1 != null)
                {
                    if (enemy1 == selected)
                    {
                        enemy1.dexterity = enemy1.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy1.name + " dexterity by " + damage;
                    }
                }
                if (enemy2 != null)
                {
                    if (enemy2 == selected)
                    {
                        enemy2.dexterity = enemy2.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy2.name + " dexterity by " + damage;
                    }
                }
                if (enemy3 != null)
                {
                    if (enemy3 == selected)
                    {
                        enemy3.dexterity = enemy3.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy3.name + " dexterity by " + damage;
                    }
                }
                if (enemy4 != null)
                {
                    if (enemy4 == selected)
                    {
                        enemy4.dexterity = enemy4.dexterity - damage;
                        playerOtherText.enabled = true;
                        playerOtherText.text = currentTurn.name + " reduced " + enemy4.name + " dexterity by " + damage;
                    }
                }

            }
            else
            {
                //no dmg done
                Debug.Log("MISS");
            }
            buttonClicked = true;
            Debug.Log("bribe3");
        }

    }

    //runaway?
    //------------------------
    void attemptRunaway()
    {
        int dex = currentTurn.dexterity;
        if (b == null)
        {
            int percentChance = dex * 5;
            int success = Random.Range(0, 100);

            if (success <= percentChance)
            {
                Debug.Log("got away!");
                battleOverText.enabled = true;
                playerFled = true;
                battleOverText.text = "You Ran Away!";
                battleOver = true;
            }
            else
            {
                playerOtherText.enabled = true;
                playerOtherText.text = "Failed to Run Away!";
                Debug.Log("fail run");
            }

        }
        buttonClicked = true;
        Debug.Log("attempted to runaway");

    }

    // Updates Player_Select option texts
    void playerSelect(int a)
    {
        option1.gameObject.SetActive(true);
        if (a == 1)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(delegate { option(1); });

            option2.onClick.RemoveAllListeners();
            option2.onClick.AddListener(delegate { option(2); });

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(delegate { option(3); });

            option4.onClick.RemoveAllListeners();
            option4.onClick.AddListener(delegate { option(4); });

            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
            option3.gameObject.SetActive(false);
            option4.gameObject.SetActive(false);

            Debug.Log("Heal Ally Player_Select");

            if (currentTurn.name != hero.name)
            {
                option1.gameObject.SetActive(true);
                option1text.text = hero.name;
            }

            //if there are party members
            if (party1 != null)
            {
                if (party1.name != currentTurn.name && party1Dead == false)
                {
                    option2.gameObject.SetActive(true);
                    option2text.text = party1.name;
                }
            }
            if (party2 != null)
            {
                if (party2.name != currentTurn.name && party2Dead == false)
                {
                    option3.gameObject.SetActive(true);
                    option3text.text = party2.name;
                }
            }

            if (party3 != null)
            {
                if (party3.name != currentTurn.name && party3Dead == false)
                {
                    option4.gameObject.SetActive(true);
                    option4text.text = party3.name;
                }
            }

            //no party member
            if (party1 == null && party2 == null && party3 == null)
            {
                option2.gameObject.SetActive(true);
                option2text.text = "No ally members...";
                option3.gameObject.SetActive(false);
                option4.gameObject.SetActive(false);
            }



        }
        else if (a == 2)
        {
            option1.onClick.RemoveAllListeners();
            option1.onClick.AddListener(delegate { option(5); });

            option2.onClick.RemoveAllListeners();
            option2.onClick.AddListener(delegate { option(6); });

            option3.onClick.RemoveAllListeners();
            option3.onClick.AddListener(delegate { option(7); });

            option4.onClick.RemoveAllListeners();
            option4.onClick.AddListener(delegate { option(8); });

            Debug.Log("Damage and Talk Player_Select");

            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
            option3.gameObject.SetActive(false);
            option4.gameObject.SetActive(false);

            //if boss then enemyparty[0] if boss
            if (b != null)
            {
                if (bDead == false)
                {
                    option1.gameObject.SetActive(true);
                    option1text.text = b.name;

                    //if there is also and enemy with the boss (ink pillar), CANNOT have a 4th in enemy party
                    if (enemy1 != null)
                    {
                        if (enemy1Dead == false)
                        {
                            option4.gameObject.SetActive(true);
                            option4text.text = enemy1.name;
                        }

                    }
                }
            }

            //if NOT boss then enemyparty[0] is enemy
            else if (enemy1 != null)
            {
                if (enemy1Dead == false)
                {
                    option1.gameObject.SetActive(true);
                    option1text.text = enemy1.name;
                }
            }
            else
            {
                Debug.Log("no enemy?");
            }

            if (enemy2 != null)
            {
                if (enemy2Dead == false)
                {
                    option2.gameObject.SetActive(true);
                    option2text.text = enemy2.name;
                }
            }

            if (enemy3 != null)
            {
                if (enemy3Dead == false)
                {
                    option3.gameObject.SetActive(true);
                    option3text.text = enemy3.name;
                }
            }

            if (enemy4 != null)
            {
                if (enemy4Dead == false)
                {
                    option4.gameObject.SetActive(true);
                    option4text.text = enemy4.name;
                }
            }
        }
        charSelected = false;
    }

    void option(int a)
    {
        if (a == 1)
        {
            selected = hero;
            Debug.Log("option1");
            charSelected = true;

        }
        else if (a == 2)
        {
            //no ally members
            if (party1 == null)
            {
                selected = hero;
            }
            else
            {
                selected = party1;
            }
            Debug.Log("option2");
            charSelected = true;

        }
        else if (a == 3)
        {
            selected = party2;
            Debug.Log("option3");
            charSelected = true;

        }
        else if (a == 4)
        {
            selected = party3;
            Debug.Log("option4");
            charSelected = true;

        }
        else if (a == 5)
        {
            if (b != null)
            {
                selected = b;
            }
            else
            {
                selected = enemy1;
            }
            Debug.Log("option5");
            charSelected = true;

        }
        else if (a == 6)
        {
            selected = enemy2;
            Debug.Log("option6");
            charSelected = true;

        }
        else if (a == 7)
        {
            selected = enemy3;
            Debug.Log("option7");
            charSelected = true;

        }
        else if (a == 8)
        {
            if (b != null)
            {
                selected = enemy1;
            }
            else
            {
                selected = enemy4;
            }
            Debug.Log("option8");
            charSelected = true;

        }

    }

    void checkbattleOver(int a)
    {
        //was players turn
        if (a == 1)
        {
            //boss health is < 0 then battle over
            if (b != null)
            {
                if (bDead == true)
                {
                    battleOver = true;
                    playerWon = true;
                }

            }
            //check all other enemy chars
            if (enemy1 != null)
            {
                if (enemy1Dead == true)
                {
                    if (enemy2 != null)
                    {
                        if (enemy2Dead == true)
                        {
                            if (enemy3 != null)
                            {
                                if (enemy3Dead == true)
                                {
                                    if (enemy4 != null)
                                    {
                                        if (enemy4Dead == true)
                                        {
                                            battleOver = true;
                                            playerWon = true;
                                        }
                                    }
                                    else
                                    {
                                        //only 3 enemies
                                        battleOver = true;
                                        playerWon = true;
                                    }
                                }
                            }
                            else
                            {
                                //only 2 enemies
                                battleOver = true;
                                playerWon = true;
                            }
                        }

                    }
                    else
                    {
                        //only 1 enemy
                        battleOver = true;
                        playerWon = true;
                    }

                }

            }

        }
        else//was enemy turn 
        {
            //check to see if player party is ALL dead
            if (heroDead == true)
            {
                if (party1 != null)
                {
                    if (party1Dead == true)
                    {
                        if (party2 != null)
                        {
                            if (party2Dead == true)
                            {
                                if (party3 != null)
                                {
                                    if (party3Dead == true)
                                    {
                                        battleOver = true;
                                        playerWon = false;
                                    }
                                }
                                else
                                {
                                    //only 2 party members
                                    battleOver = true;
                                    playerWon = false;
                                }
                            }
                        }
                        else
                        {
                            //only 1 party member
                            battleOver = true;
                            playerWon = false;
                        }
                    }

                }
                else
                {
                    //only hero
                    battleOver = true;
                    playerWon = false;
                }

            }
        }
    }

    void Update()
    {
        heroText.text = "Health: " + (hero.currenthealth) + " / " + hero.maxhealth;
        if (party1 != null)
        {
            party1Text.text = "Health: " + (party1.currenthealth) + " / " + party1.maxhealth;
        }
        if (party2 != null)
        {
            party2Text.text = "Health: " + (party2.currenthealth) + " / " + party2.maxhealth;
        }
        if (party3 != null)
        {
            party3Text.text = "Health: " + (party3.currenthealth) + " / " + party3.maxhealth;
        }

        if (enemy1 != null)
        {
            enemy1Text.text = "Health: " + (enemy1.currenthealth) + " / " + enemy1.maxhealth;
        }
        if (enemy2 != null)
        {
            enemy2Text.text = "Health: " + (enemy2.currenthealth) + " / " + enemy2.maxhealth;
        }
        if (enemy3 != null)
        {
            enemy3Text.text = "Health: " + (enemy3.currenthealth) + " / " + enemy3.maxhealth;
        }
        if (enemy4 != null)
        {
            enemy4Text.text = "Health: " + (enemy4.currenthealth) + " / " + enemy4.maxhealth;
        }

        if (b != null)
        {
            btext.text = "Health: " + (b.currenthealth) + " / " + b.maxhealth;
        }

    }

    void leaveBattle(bool win, bool f)
    {
        battleOverText.enabled = true;
        Debug.Log("leave battle");
        if (win == true)
        {
            Debug.Log("leave battle win");
            double amount = 0;
            int xp = 0;
            //won battle
            //award xp and gold
            if (b != null)
            {
                if (Game.current.boss.name == Game.current.unicorn.name)
                {
                    amount = 1092381342312;
                    Game.current.player.unicorn = true;
                    xp = 500;
                }
                else if (Game.current.boss.name == Game.current.goblin.name)
                {
                    amount = 127632232341276;
                    Game.current.player.goblins = true;
                    xp = 500;
                }
                else if (Game.current.boss.name == Game.current.ink.name)
                {
                    amount = 4798174146871673123;
                    Game.current.player.finalBoss = true;
                    xp = 1000;
                }
                else if (Game.current.boss.name == Game.current.sheep.name)
                {
                    amount = 1;
                    Game.current.sheepDead = true;
                    xp = 100;
                }
                else if (Game.current.boss.name == Game.current.farmer.name)
                {
                    amount = 1;
                    Game.current.farmerDead = true;
                    xp = 100;
                }
                else if (Game.current.boss.name == Game.current.cow.name)
                {
                    amount = 1;
                    Game.current.cowDead = true;
                    xp = 100;
                }
                Game.current.boss = null;
            }
            else
            {
                //Debug.Log("in win == true, but no boss");
                amount = Random.Range(1000000, 90000000);
                xp = xpcalc();
            }
            //Debug.Log("xp is " + xp);
            // Debug.Log("amount is " + amount);'
            bool leveled = addXp(xp);
            if (!leveled)
            {
                battleOverText.text = "You received " + amount + " gp. \n" + xp + " xp.";
            }
            else
            {
                battleOverText.text = "You received " + amount + " gp. \n" + xp + " xp and one of your characters leveled up.";
            }
            Game.current.player.gold = Game.current.player.gold + amount;

            //modify player to hurt status?----------------Currently not on until healing out of combat mechanic added

            //partyHealth();



        }
        else if (f == true)
        {
            Debug.Log("leave battle fled");
            //ran away
            //modify player to hurt status?

            //partyHealth();

            //no xp and gold
            battleOverText.text = "You ran away. Receive no gp or xp.";
        }
        else if (win == false)
        {
            Debug.Log("leave battle lost");
            //lost battle
            //player revives in town
            Game.current.player.x = 0f;
            Game.current.player.y = 4f;
            //no xp and gold
            battleOverText.text = "You lost. Receive no gp or xp.";
        }
        else
        {
            Debug.Log("leave battle broken");
            //idk what happened?
            battleOverText.text = "Something broke...";
        }
    }

    bool addXp(int xp)
    {
        bool leveled = Game.current.player.addXp(xp);
        //check for player party members
        for(int i=0; i < 3; i++)
        {
            if(Game.current.party[i] != null)
            {
                if (leveled)
                {
                    Game.current.party[i].addXp(xp);
                }else
                {
                    leveled = Game.current.party[i].addXp(xp);
                }
            }
        }
        return leveled;
    }

    int xpcalc()
    {
        //Debug.Log("in xpcalc");
        int xp = 0;

        if (enemy1 != null)
        {
            if (enemy1.charactertype == "bear")
            {
                xp = xp + 250;
            }
            else if (enemy1.charactertype == "rat")
            {
                xp = xp + 50;
            }
            else if (enemy1.charactertype == "jelly")
            {
                xp = xp + 100;
            }
            else
            {
                //something else?
                xp = xp + 1;
            }

        }
        if (enemy2 != null)
        {
            if (enemy2.charactertype == "bear")
            {
                xp = xp + 250;
            }
            else if (enemy2.charactertype == "rat")
            {
                xp = xp + 50;
            }
            else if (enemy2.charactertype == "jelly")
            {
                xp = xp + 100;
            }
            else
            {
                //something else?
                xp = xp + 1;
            }
        }

        if (enemy3 != null)
        {
            if (enemy3.charactertype == "bear")
            {
                xp = xp + 250;
            }
            else if (enemy3.charactertype == "rat")
            {
                xp = xp + 50;
            }
            else if (enemy3.charactertype == "jelly")
            {
                xp = xp + 100;
            }
            else
            {
                //something else?
                xp = xp + 1;
            }
        }
        if (enemy4 != null)
        {
            if (enemy4.charactertype == "bear")
            {
                xp = xp + 250;
            }
            else if (enemy4.charactertype == "rat")
            {
                xp = xp + 50;
            }
            else if (enemy4.charactertype == "jelly")
            {
                xp = xp + 100;
            }
            else
            {
                //something else?
                xp = xp + 1;
            }
        }

        return xp;
    }

    //turn on if you want party to NOT be healed when leaving combat
    void partyHealth()
    {
        Game.current.player.currenthealth = hero.currenthealth;
        if (party1 != null)
        {
            Game.current.party[0].currenthealth = party1.currenthealth;
        }
        if (party2 != null)
        {
            Game.current.party[1].currenthealth = party1.currenthealth;
        }
        if (party3 != null)
        {
            Game.current.party[2].currenthealth = party1.currenthealth;
        }
    }

    /*chooseTarget()
     * 
     * Picks a random number 0,1,2,3
     * Checks to see if a party member exists at that number (0 is hero) (1->3) are the party members
     * if no party member is avalible at number, set to previous partymember
     */
    void chooseTarget()
    {
        bool choosen = false;
        int rand = Random.Range(0, 4);
        Debug.Log(rand);
        while (choosen == false)
        {
            if (rand == 0)
            {

                if (hero.currenthealth > 0)
                {
                    selected = hero;
                    choosen = true;
                }
                else
                {
                    rand = 1;
                }

            }

            if (rand == 1)
            {
                //there is a party member
                if (party1 != null)
                {
                    if (party1.currenthealth > 0)
                    {
                        selected = party1;
                        choosen = true;
                    }
                    else
                    {
                        rand = 2;
                    }
                }
                else //there is not a partymember
                {
                    rand = 0;
                }
            }

            if (rand == 2)
            {
                if (party2 != null)
                {
                    if (party2.currenthealth > 0)
                    {
                        selected = party2;
                        choosen = true;
                    }
                    else
                    {
                        rand = 3;
                    }
                }
                else //there is not a partymember
                {
                    rand = 1;
                }
            }

            if (rand == 3)
            {
                if (party3 != null)
                {
                    if (party3.currenthealth > 0)
                    {
                        selected = party3;
                        choosen = true;
                    }
                    else
                    {
                        rand = 0;
                    }
                }
                else //there is not a partymember
                {
                    rand = 2;
                }
            }
        }
        //selected = hero;
        Debug.Log("selected is " + selected.name);

    }

    bool isDead(Character c)
    {
        Debug.Log("is Dead?");
        if (c.currenthealth <= 0)
        {
            if (hero == c)
            {
                //hero dead
                heroDead = true;
                return true;
            }
            else if (party1 == c)
            {
                party1Dead = true;
                return true;
            }
            else if (party2 == c)
            {
                party2Dead = true;
                return true;
            }
            else if (party3 == c)
            {
                party3Dead = true;
                return true;
            }
            else if (b == c)
            {
                //boss dead
                bDead = true;
                return true;
            }
            else if (enemy1 == c)
            {
                enemy1Dead = true;
                Debug.Log("enemy1dead");
                return true;
            }
            else if (enemy2 == c)
            {
                enemy2Dead = true;
                return true;
            }
            else if (enemy3 == c)
            {
                enemy3Dead = true;
                return true;
            }
            else if (enemy4 == c)
            {
                enemy4Dead = true;
                return true;
            }
            else
            {
                //error
                Debug.Log("Error in isDead no match found");
                return false;
            }
        }
        else
        {
            Debug.Log("Selected char is not dead");
            return false;
        }
    }

    void removeDead(bool chardead)
    {
        if (chardead == true)
        {
            //the selected char is dead

            //figure out which turn was char (next1..2..3..)
            for (int i = 0; i < orderedChars.Count; i++)
            {
                if (selected == orderedChars[i])
                {
                    //remove character from orderedChars
                    orderedChars.RemoveAt(i);
                }
            }

            //figure out who was char (enemy1...party1...)
            if (selected == hero)
            {
                heroSprite.enabled = false;
                heroText.enabled = false;
            }
            else if (selected == party1)
            {
                party1Sprite.enabled = false;
                party1Text.enabled = false;
            }
            else if (selected == party2)
            {
                party2Sprite.enabled = false;
                party2Text.enabled = false;
            }
            else if (selected == party3)
            {
                party3Sprite.enabled = false;
                party3Text.enabled = false;
            }
            else if (selected == b)
            {
                bSprite.enabled = false;
                btext.enabled = false;
            }
            else if (selected == enemy1)
            {
                enemy1Sprite.enabled = false;
                enemy1Text.enabled = false;
            }
            else if (selected == enemy2)
            {
                enemy2Sprite.enabled = false;
                enemy2Text.enabled = false;
            }
            else if (selected == enemy3)
            {
                enemy3Sprite.enabled = false;
                enemy3Text.enabled = false;
            }
            else if (selected == enemy4)
            {
                enemy4Sprite.enabled = false;
                enemy4Text.enabled = false;
            }
            else
            {
                //error has occured
                Debug.Log("REMOVE DEAD ERROR: not seleced char match made");
            }


        }

    }

    void loadSprites()
    {
        turn_2.enabled = false;
        turn_3.enabled = false;
        turn_4.enabled = false;
        turn_5.enabled = false;
        turn_6.enabled = false;
        turn_7.enabled = false;

        for (int i = 0; i < orderedChars.Count; i++)
        {
            if (i == 0)
            {
                turn_current.sprite = Resources.Load(orderedChars[0].charactertype, typeof(Sprite)) as Sprite;
                currentTurn = orderedChars[0];
            }
            else if (i == 1)
            {
                turn_1.sprite = Resources.Load(orderedChars[1].charactertype, typeof(Sprite)) as Sprite;

            }
            else if (i == 2)
            {
                turn_2.enabled = true;
                turn_2.sprite = Resources.Load(orderedChars[2].charactertype, typeof(Sprite)) as Sprite;
            }
            else if (i == 3)
            {
                turn_3.enabled = true;
                turn_3.sprite = Resources.Load(orderedChars[3].charactertype, typeof(Sprite)) as Sprite;
            }
            else if (i == 4)
            {
                turn_4.enabled = true;
                turn_4.sprite = Resources.Load(orderedChars[4].charactertype, typeof(Sprite)) as Sprite;
            }
            else if (i == 5)
            {
                turn_5.enabled = true;
                turn_5.sprite = Resources.Load(orderedChars[5].charactertype, typeof(Sprite)) as Sprite;
            }
            else if (i == 6)
            {
                turn_6.enabled = true;
                turn_6.sprite = Resources.Load(orderedChars[6].charactertype, typeof(Sprite)) as Sprite;
            }
            else if (i == 7)
            {
                turn_7.enabled = true;
                turn_7.sprite = Resources.Load(orderedChars[7].charactertype, typeof(Sprite)) as Sprite;
            }
        }
    }

    //health calc
    int healthCalc(int currentHp, int damage)
    {
        if (damage > currentHp)
        {
            return 0;
        }
        else
        {
            return currentHp - damage;
        }
    }
}
