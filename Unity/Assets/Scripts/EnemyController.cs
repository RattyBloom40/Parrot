using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Vector2[] path;
    private int index = 0;

    public enum State {
        Patrol,
        HuntPlayer
    }

    public State state;

    void Update() {
        switch(state) {
            case State.Patrol:
                if (PathTo(path[index])){
                    index = index >= path.Length-1 ? 0 : ++index;
                }
                break;
            case State.HuntPlayer:
                PathTo(PlayerController.player.transform.position);
                break;
        }
    }

    bool PathTo(Vector2 place)
    {
        return true;
    }
}
