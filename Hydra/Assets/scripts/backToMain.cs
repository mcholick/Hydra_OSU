using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMainMenu : MonoBehaviour
{

    void OnMouseDown()
    {
        SceneManager.LoadScene("_MainScene");
    }

}