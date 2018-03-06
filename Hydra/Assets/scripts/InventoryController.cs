using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public RawImage horn;
    public RawImage heads;
    public RawImage booze;
    public RawImage milk;
    public Text gold;
	
	// Update is called once per frame
	void Update () {
        if (Game.current.player.horn)
        {
            horn.uvRect = new Rect(0, 0, 1, 1);
        }
        else
        {
            horn.uvRect = new Rect(0, 0, 0, 0);
        }
        if (Game.current.player.booze)
        {
            booze.uvRect = new Rect(0, 0, 1, 1);
        }
        if (Game.current.player.milk)
        {
            milk.uvRect = new Rect(0, 0, 1, 1);
        }
        if (Game.current.player.heads)
        {
            heads.uvRect = new Rect(0, 0, 1, 1);
        }
        else
        {
            heads.uvRect = new Rect(0, 0, 0, 0);
        }
        gold.text = "Gold: " + Game.current.player.gold;
    }
}
