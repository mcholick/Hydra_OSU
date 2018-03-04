using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenesUnicorn : MonoBehaviour {

    public GameObject horn;

    // Use this for initialization
    void Start () {
        if (Game.current.player.unicorn == true)
        {
            if (Game.current.player.horn == false && horn != null)
            {
                horn.transform.position = transform.position;
            }
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("unicornDialogue");
    }
}
