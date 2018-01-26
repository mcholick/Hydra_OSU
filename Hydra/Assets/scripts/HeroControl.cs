using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour {

    public float speed; //controls hero's pace



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float adjustedSpeed = speed;  //used to make sure player can't go faster diagonally
        //vertical movement
        if (Input.GetAxisRaw("Vertical") != 0) {
            if(Input.GetAxisRaw("Horizontal") != 0)
                adjustedSpeed = Mathf.Sqrt(speed);
            transform.Translate(0, adjustedSpeed*Input.GetAxisRaw("Vertical")/100,0);
        }
        //horizontal movement
        if (Input.GetAxisRaw("Horizontal") != 0) {
            if (Input.GetAxisRaw("Vertical") != 0)
                adjustedSpeed = Mathf.Sqrt(speed);
            transform.Translate(adjustedSpeed*Input.GetAxisRaw("Horizontal") / 100, 0, 0);
        }
	}
}
