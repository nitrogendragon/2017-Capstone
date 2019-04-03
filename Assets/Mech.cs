using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour {
    Animator anim;
    CharacterController controller;
    public float speed = 106.0f;
    public float turnspeed = 80.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 30.0f;
	// Use this for initialization
	void Awake () {
        anim = gameObject.GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("up") || Input.GetKey("down"))
        {
            speed = 24;
            anim.SetInteger("AnimPar", 1);
        }
        else
        {
            anim.SetInteger("AnimPar", 0);
            speed = 0;
        }
     
        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnspeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
	}
}
