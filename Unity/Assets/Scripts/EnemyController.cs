/*
Need to finish weapon.Attack()
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  @author Andrew
public class EnemyController : MonoBehaviour {

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        for (int x = 0; x < path.Length; x++)
        {
            Gizmos.DrawSphere(path[x], .5f);
        }
    }

    public Vector2[] path; //maybe work as path!
    public float speed; //unique attributes
    public Weapon weapon;

    private float enemyX; //used for position
    private float enemyY;
    private Rigidbody2D rb2d;
    private Vector2 aimDir;

    private AttackManager attackManager;

    private RaycastHit2D toPlayer; //ray from enemy to player
    private Vector2 playerPos; //stores last seen position
    private bool search; //used to keep track of last seen position

    void Start()
    {
        //attackManager = new AttackManager(weapon);
        rb2d = GetComponent<Rigidbody2D>();
        enemyX = transform.position.x;
        enemyY = transform.position.y;
        search = true;
    }

    private int index = 0; //used for movement loop

    public enum State {
        Patrol,
        HuntPlayer
    }

    public State state;
    private Vector2 pathTowards;

    void Update() {
        pathTowards = Vector2.zero;
        Vector3 newDir;
        switch(state) { //different behaviors for movement
            case State.Patrol:
                if (path.Length > 0)
                {
                    if (PathTo(path[index]).magnitude < .5f)
                    { //if pathTo returns current position *OR* past
                        index = index >= path.Length - 1 ? 0 : ++index; //if reached path point, go to next path point *ALSO* change aimDir towards next path point
                    }
                    newDir = Vector3.RotateTowards(-transform.right, new Vector3(enemyX, enemyY, 0) - new Vector3(path[index].x, path[index].y, 0), 100, 100);
                    aimDir = -(newDir.normalized);
                    pathTowards = PathTo(path[index]); //movement = towards player
                }
                toPlayer = Physics2D.Raycast(transform.position, PlayerController.player.transform.position);
                if (toPlayer.collider.gameObject.GetComponent<PlayerController>() != null)
                {
                    state = State.HuntPlayer; //hunt down mr. player when "see"
                }
                break;
            case State.HuntPlayer:
                newDir = Vector3.RotateTowards(-transform.right, new Vector3(enemyX, enemyY, 0) - new Vector3(PlayerController.player.transform.position.x, PlayerController.player.transform.position.y, 0), 100, 100);
                aimDir = -(newDir.normalized);
                if (PathTo(PlayerController.player.transform.position, weapon).magnitude<.5f){ //path towards the player with weaponRange in between *ALSO* aimDir towards player
                    //attackManager.Attack(aimDir);
                }
                else
                {
                    pathTowards = (PathTo(PlayerController.player.transform.position, weapon)); //movement = towards player
                }
                toPlayer = Physics2D.Raycast(transform.position, PlayerController.player.transform.position);
                if (toPlayer.collider.gameObject.GetComponent<PlayerController>() == null && !search && Vector2.Distance(transform.position,playerPos)!=0)
                {
                    pathTowards = playerPos;//move towards last seen position
                }
                else if (toPlayer.collider.gameObject.GetComponent<PlayerController>() == null && !search && Vector2.Distance(transform.position, playerPos) == 0)
                {
                    search = true;
                    state = State.Patrol; //return to patrol
                }
                else if (toPlayer.collider.gameObject.GetComponent<PlayerController>() == null && search)
                {
                    playerPos = new Vector2(PlayerController.player.transform.position.x, PlayerController.player.transform.position.y);
                    search = false;
                    //set last seen position
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = pathTowards.normalized * speed;
    }

    Vector2 PathTo(Vector2 place)
    {
        //give pathPoint towards place w/ regards to speed and walls
        //use NavMesh
        return place; //when reach *OR* past pathPoint
    }

    Vector2 PathTo(Vector2 place, Weapon weapon)
    {
        //give pathPoint towards place w/ regards to speed and walls and weaponRange
        //use NavMesh
        return place; //when reach *OR* past optimal range
    }
}
