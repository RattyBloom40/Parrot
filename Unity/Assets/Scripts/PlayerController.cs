using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public enum Status {
        Normal,
        Dodging
    }

    public float speed; //store the player's movement speed
    private Rigidbody2D rb2d; //reference to Rigidbody for Physics
    float mouseX;
    float mouseY;
    float playerX;
    float playerY;
    Transform target;

    void Start () {
        //set r2bd to a reference of the rigidbody so it can be accessed later
        rb2d = GetComponent<Rigidbody2D>();
	}
    void Update() {
        mouseX = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x;
        mouseY = Camera.main.ScreenToWorldPoint(new Vector2(0, Input.mousePosition.y)).y;
        playerX = transform.position.x;
        playerY = transform.position.y;
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(-transform.right ,new Vector3(playerX, playerY, 0) - new Vector3(mouseX, mouseY, 0), step, 0.0f);
        
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.FromToRotation(Vector3.left,newDir);
    }
    void FixedUpdate() {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // use the horizontal and vertical axes to create a vector with variable movement
        rb2d.velocity = (movement * speed); // set the player speed to the current speed rather than adding or subtacting to eliminate acceleration and deceleration times
    }
}
