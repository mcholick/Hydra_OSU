using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    public GameObject focus;  //gameobject the camera will follow
    public float speed;
    private Vector3 position;  //need 3rd dim to have cam sit above player


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        position = new Vector3(focus.transform.position.x, focus.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, position, speed*Time.deltaTime);
	}
}
