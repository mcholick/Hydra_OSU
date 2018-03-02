using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMapCowMilk : MonoBehaviour
{

    // Update is called once per frame
    void OnMouseDown()
    {
        Game.current.gotMilk = true;
        Game.current.milkOnGround = true;
        SceneManager.LoadScene("main_map");
    }
}
