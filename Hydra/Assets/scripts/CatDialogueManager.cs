using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatDialogueManager : MonoBehaviour {

    public Camera[] cameras;

    // Use this for initialization
    void Start () {
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }
        cameras[0].gameObject.SetActive(true);
    }
	
}
