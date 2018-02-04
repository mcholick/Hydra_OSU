using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour {

    public float speed; //controls hero's pace

    private List<System.String> Inventory;//holds hero's stuff

    private CircleCollider2D hitbox;  //used for collecting and interacting with close objects

    private Animator anim;

    private Collision2D collision;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float adjustedSpeed = speed;  //used to make sure player can't go faster diagonally


        //vertical movement
        if (Input.GetAxisRaw("Vertical") != 0) {
            //character will always default to facing up or down if any vertical motion occurs
            anim.SetBool("MovedRight", false);
            anim.SetBool("MovedLeft", false);
            //prepare for next idle state
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                anim.SetBool("MovedUp", true);
                anim.SetBool("MovedDown", false);
            } else {
                anim.SetBool("MovedDown", true);
                anim.SetBool("MovedUp", false);
            }

            if (Input.GetAxisRaw("Horizontal") != 0)
                adjustedSpeed = Mathf.Sqrt(speed);
            transform.Translate(0, adjustedSpeed * Input.GetAxisRaw("Vertical") / 100, 0);
        }
        //horizontal movement
        if (Input.GetAxisRaw("Horizontal") != 0) {
            if (Input.GetAxisRaw("Horizontal") >= 0)
            {
                anim.SetBool("MovedRight", true);
                anim.SetBool("MovedLeft", false);
            } else {
                anim.SetBool("MovedLeft", true);
                anim.SetBool("MovedRight", false);
            }
            if (Input.GetAxisRaw("Vertical") != 0)
                adjustedSpeed = Mathf.Sqrt(speed);
            transform.Translate(adjustedSpeed * Input.GetAxisRaw("Horizontal") / 100, 0, 0);
        }

        //set anim floats for walking animations
        anim.SetFloat("MovingX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MovingY", Input.GetAxisRaw("Vertical"));

        //create controls for collecting and storing collectibles
        if (Input.GetKeyDown("space")){
            if (collision.gameObject.CompareTag("key")) {
                print("You Just Collected ");

            }
        }
    }


}
