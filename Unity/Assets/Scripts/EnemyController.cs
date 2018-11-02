using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public enum State {
        Patrol,
        HuntPlayer
    }

    public State state;

    void Update() {
        switch(state) {
            case State.Patrol:

                break;
            case State.HuntPlayer:

                break;
        }
    }
}
