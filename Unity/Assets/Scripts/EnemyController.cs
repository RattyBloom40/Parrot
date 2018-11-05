using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Vector2[] path; //unique attributes
    public float speed;
    public Weapon weapon;

    private float enemyX; //used for position
    private float enemyY;
    private Rigidbody2D rb2d;

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
                if (PathTo(path[index])){
                    index = index >= path.Length-1 ? 0 : ++index; //if reached path point, go to next path point
                }
                break;
            case State.HuntPlayer:
                PathTo(PlayerController.player.transform.position,weapon); //path towards the player with weaponRange in between
                switch (weapon.type) {
                    case Weapon.Type.Melee:
                        break;
                    case Weapon.Type.Ranged:
                        //go pew pew
                        break;
                }
                break;
        }
    }

    bool PathTo(Vector2 place)
    {

        return true;
    }

    bool PathTo(Vector2 place, Weapon weapon)
    {

        return true;
    }
}
