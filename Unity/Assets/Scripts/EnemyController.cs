/*
Need to finish weapon.Attack() and update aimDir
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  @author Andrew
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
        Vector2 pathTowards;
        switch(state) {
            case State.Patrol:
                if (PathTo(path[index]).Equals(path[index])){ //if pathTo returns current position
                    index = index >= path.Length-1 ? 0 : ++index; //if reached path point, go to next path point *ALSO* change aimDir towards next path point
                }
                else{
                    pathTowards = PathTo(path[index]); //movement = towards player
                }
                break;
            case State.HuntPlayer:
                if (PathTo(PlayerController.player.transform.position, weapon).magnitude<.5f){ //path towards the player with weaponRange in between *ALSO* aimDir towards player
                    weapon.Attack(aimDir);
                }
                else
                {
                    pathTowards = (PathTo(PlayerController.player.transform.position, weapon)); //movement = towards player
                }
                break;
        }
        //move to pathTowards
    }

    Vector2 PathTo(Vector2 place)
    {
        //give pathPoint towards place w/ regards to speed and walls
        return place; //when reach *OR* past pathPoint
    }

    Vector2 PathTo(Vector2 place, Weapon weapon)
    {
        //give pathPoint towards place w/ regards to speed and walls and weaponRange
        return place; //when reach *OR* past optimal range
    }
}
