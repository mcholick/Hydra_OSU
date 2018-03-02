using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionScene : MonoBehaviour {

    public GameObject farmer;
    public GameObject drunkard;
    public GameObject innkeeper;
    public GameObject cat;
    public GameObject sheep;
    public GameObject cow;
    public GameObject unicorn;

    // Use this for initialization
    void Start () {
        switch (Game.current.interactionChar)
        {
            case 1:
                farmer.transform.position = transform.position;
                break;
            case 2:
                drunkard.transform.position = transform.position;
                break;
            case 3:
                innkeeper.transform.position = transform.position;
                break;
            case 4:
                cat.transform.position = transform.position;
                break;
            case 5:
                sheep.transform.position = transform.position;
                break;
            case 6:
                cow.transform.position = transform.position;
                break;
            case 7:
                unicorn.transform.position = transform.position;
                break;
            case 8:
                innkeeper.transform.position = transform.position;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
