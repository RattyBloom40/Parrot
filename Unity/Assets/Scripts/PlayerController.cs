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
    public GameObject cursor;
    Transform target;
    float speed2;//speed used for transform.lookAt Method
    // Use this for initialization
    void Start () {
        //set r2bd to a reference of the rigidbody so it can be accessed later
        rb2d = GetComponent<Rigidbody2D>();
	}
    void Update()
    {
        //Below Code Moves Player Perspective
        //
        mouseX = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x;
        mouseY = Camera.main.ScreenToWorldPoint(new Vector2(0, Input.mousePosition.y)).y;
        playerX = transform.position.x;
        playerY = transform.position.y;
        /*
         if (mouseX>playerX&&mouseY>playerY)//if the mouse is in quadrant 1 in relation to the player
         {
             transform.rotation = Quaternion.Euler(0,0,Mathf.Abs(Mathf.Rad2Deg*(Mathf.Atan(mouseY-playerY/mouseX-playerX))));
         }
         else if (mouseX < playerX && mouseY > playerY)//if the mouse is in quadrant 2 in relation to the player
         {
             transform.rotation = Quaternion.Euler(0, 0, 180 - Mathf.Abs(Mathf.Rad2Deg * (Mathf.Atan(mouseY - playerY / mouseX - playerX))));
         }
         else if (mouseX < playerX && mouseY < playerY)//if the mouse is in quadrant 3 in relation to the player
         {
             transform.rotation = Quaternion.Euler(0, 0, 180 + Mathf.Abs(Mathf.Rad2Deg * (Mathf.Atan(mouseY - playerY / mouseX - playerX))));
         }
         else if (mouseX > playerX && mouseY < playerY)//if the mouse is in quadrant 4 in relation to the player
         {
             transform.rotation = Quaternion.Euler(0, 0, 360 - Mathf.Abs(Mathf.Rad2Deg * (Mathf.Atan(mouseY - playerY / mouseX - playerX))));
         }
         else if(mouseX-playerX==0&&mouseY-playerY>0)//if the angle is exactly 90
         {
             transform.rotation = Quaternion.Euler(0, 0, 90);
         }
         else if (mouseX - playerX == 0 && mouseY - playerY < 0)//if the angle is 270
         {
             transform.rotation = Quaternion.Euler(0, 0, 270);
         }
         else if (mouseX - playerX >0 && mouseY-playerY == 0)//if the angle is 0
         {
             transform.rotation = Quaternion.Euler(0, 0, 0);
         }
         else if (mouseX - playerX < 0 && mouseY - playerY == 0)//if the angle is 180
         {
             transform.rotation = Quaternion.Euler(0, 0, 180);
         }
         Debug.Log((mouseY - playerY) + "/" + (mouseX - playerX)+", "+ transform.rotation.eulerAngles.z);*/


        /*cursor.transform.position = new Vector3(mouseX, mouseY, 0);
        transform.LookAt(cursor.transform.position, new Vector3(1, 0, 0));*/

        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(-transform.right ,new Vector3(playerX, playerY, 0) - new Vector3(mouseX, mouseY, 0), step, 0.0f);
        
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.FromToRotation(Vector3.left,newDir);
        
        //
    }
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // use the horizontal and vertical axes to create a vector with varialbe movement
        rb2d.velocity = (movement * speed); // set the player speed to the current speed rather than adding or subtacting to eliminate acceleration and deceleration times
    }
}
