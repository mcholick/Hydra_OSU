using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkScript : MonoBehaviour {

    private BoxCollider2D box;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("hero")) {
            print("Scene Transition");
        }
    }
}
