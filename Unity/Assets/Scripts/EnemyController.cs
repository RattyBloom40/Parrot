/*
Need to finish weapon.Attack() and update aimDir
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Vector2[] path; //maybe work as path?
    public float speed; //unique attributes
    public Weapon weapon;

    private float enemyX; //used for position
    private float enemyY;
    private Rigidbody2D rb2d;
    private Vector2 aimDir;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyX = transform.position.x;
        enemyY = transform.position.y;
    }

    private int index = 0; //used for movement loop

    public enum State {
        Patrol,
        HuntPlayer
    }

    public State state;

    void Update() {
        switch(state) {
            case State.Patrol:
                if (PathTo(path[index])){ //path towards path point
                    index = index >= path.Length-1 ? 0 : ++index; //if reached path point, go to next path point
                }
                break;
            case State.HuntPlayer:
                if (PathTo(PlayerController.player.transform.position, weapon)) //path towards the player with weaponRange in between
                { 
                    weapon.Attack(aimDir);
                }
                break;
        }
    }

    bool PathTo(Vector2 place)
    {
        //move towards place w/ regards to speed and walls
        return true; //when reach
    }

    bool PathTo(Vector2 place, Weapon weapon)
    {
        //move towards place w/ regards to speed and walls and weaponRange *ALSO* aimDir towards player
        return true; //when reach
    }
}
