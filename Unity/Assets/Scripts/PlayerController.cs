﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed; //store the player's movement speed
    private Rigidbody2D rb2d; //reference to Rigidbody for Physics

	// Use this for initialization
	void Start () {
        //set r2bd to a reference of the rigidbody so it can be accessed later
        rb2d = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // gets player's horizontal movement
        float moveVeritcal = Input.GetAxis("Vertical"); //gets player's vertical movement
        Vector2 movement = new Vector2(moveHorizontal, moveVeritcal); //use the horizontal and vertical variables to create a vector with varialbe movement
        rb2d.velocity = (movement * speed);//set the player speed to the current speed rather than adding or subtacting to eliminate acceleration and deceleration times
    }
}
