using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed; //store the player's movement speed
    private Rigidbody2D rb2d; //reference to Rigidbody for Physics
    float mouseX;
    float mouseY;
    float playerX;
    float playerY;
    // Use this for initialization
    void Start () {
        //set r2bd to a reference of the rigidbody so it can be accessed later
        rb2d = GetComponent<Rigidbody2D>();
	}
    void Update()
    {
        //Below Code Moves Player Perspective
        /*
        mouseX = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x;
        mouseY = Camera.main.ScreenToWorldPoint(new Vector2(0, Input.mousePosition.y)).y;
        playerX = transform.position.x;
        playerY = transform.position.y;
        if (mouseX<playerX&&mouseY<playerY)//if the mouse is in quadrant one in relation to the player
        {
            transform.rotation = Quaternion.Euler(0,0,Mathf.Rad2Deg*(Mathf.Atan(mouseY-playerY/mouseX-playerX)));
        }
        Debug.Log((mouseY - playerY) + "/" + (mouseX - playerX)+", "+ Mathf.Atan(mouseY - playerY / mouseX - playerX));
        else if()//if the mouse is in the second quadrant in relation to the player
        */
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // use the horizontal and vertical axes to create a vector with varialbe movement
        rb2d.velocity = (movement * speed); // set the player speed to the current speed rather than adding or subtacting to eliminate acceleration and deceleration times
    }
}
