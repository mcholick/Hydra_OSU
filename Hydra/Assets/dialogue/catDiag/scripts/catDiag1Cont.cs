using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catDiag1Cont : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;

    void OnMouseDown()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
    }
}
