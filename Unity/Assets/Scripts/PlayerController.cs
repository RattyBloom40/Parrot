using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public enum Status {
        Normal,
        Dodging
    }
    Status status = Status.Normal;
   
    //************************************* Singleton ******************************************//

    public static PlayerController player;

    void Awake() {
        if (player == null)
            player = this;
        else
            Debug.Log("Error: 2 PlayerControllers active");
    }

    //************************************* Singleton ******************************************//
    public CameraController cam;

    public float speed; //store the player's movement speed
    public float dodgeMulti = 1.4f;

    private Rigidbody2D rb2d; //reference to Rigidbody for Physics
    float mouseX;
    float mouseY;
    float playerX;
    float playerY;

    public GameObject entities;

    public Vector2 dodge;
    public Vector2 aimDir;
    public float dodgeTime;

    void Start () {
        //set r2bd to a reference of the rigidbody so it can be accessed later
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Update() {
        switch (status) {
            case Status.Normal:
                mouseX = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)).x;
                mouseY = Camera.main.ScreenToWorldPoint(new Vector2(0, Input.mousePosition.y)).y;
                playerX = transform.position.x;
                playerY = transform.position.y;
                //float step = speed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(-transform.right, new Vector3(playerX, playerY, 0) - new Vector3(mouseX, mouseY, 0),100,100);
                aimDir = -newDir;
                transform.rotation = Quaternion.FromToRotation(Vector3.left, newDir);
                if(Input.GetButtonDown("Fire2")) {
                    dodge = rb2d.velocity.normalized;
                    status = Status.Dodging;
                    StartCoroutine(doADodge());
                    cam.freeze = true;
                }
                break;
            case Status.Dodging:

                break;
        }
    }

    void FixedUpdate() {
        switch (status) {
            case Status.Normal:
                Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // use the horizontal and vertical axes to create a vector with variable movement
                rb2d.velocity = (movement.normalized * speed); // set the player speed to the current speed rather than adding or subtacting to eliminate acceleration and deceleration times
                break;
            case Status.Dodging:
                rb2d.velocity = dodge.normalized * speed * dodgeMulti;
                break;
        }
    }

    IEnumerator doADodge() {
        yield return new WaitForSeconds(dodgeTime);
        status = Status.Normal;
        cam.freeze = false;
    }
}
