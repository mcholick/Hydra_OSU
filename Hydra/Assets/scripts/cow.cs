﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cow : MonoBehaviour {

    private bool inArea = false;
    public GameObject milk;

    // Use this for initialization
    void Start()
    {
        if (Game.current.milkOnGround == true)
        {
            milk.transform.position = new Vector3((float)3.292, (float)-2.152, 0);
        }
        if (Game.current.cowDead == true)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inArea = false;
        }
    }

    void Update()
    {
        if (inArea && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("cowDialogue");
        }
    }
}