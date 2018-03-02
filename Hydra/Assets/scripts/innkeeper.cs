using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class innkeeper : MonoBehaviour {

    private bool inArea = false;
    public GameObject booze;

    private void Start()
    {
        if (Game.current.boozeOnGround)
        {
            booze.transform.position = new Vector3((float)-2.556, (float)-2.283, 0);
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
            SceneManager.LoadScene("innkeeperDialogue");
        }
    }
}
