using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactBeta : MonoBehaviour {

    public GameObject troll;
    private bool inArea = false;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inArea = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inArea = false;
    }


    // Update is called once per frame
    void Update () {
		if(inArea && Input.GetKeyDown("space"))
        {
            troll.transform.position = transform.position;
        }
	}
}
