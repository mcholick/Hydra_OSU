using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

    public Text heroLvl;
    public Text catLvl;
    public Text farmerLvl;
    public Text sheepLvl;
    public Text drunkLvl;
    public Text goldEarned;


    // Use this for initialization
    void Start () {
        heroLvl.text = Game.current.player.level.ToString();
        catLvl.text = Game.current.cat.level.ToString();
        farmerLvl.text = Game.current.farmer.level.ToString();
        sheepLvl.text = Game.current.sheep.level.ToString();
        drunkLvl.text = Game.current.drunkard.level.ToString();
        goldEarned.text = Game.current.player.gold.ToString();
	}

}
