using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    Thread.NavMesh navMesh;

    void OnDrawGizmos() {
        
    }

    void Awake() {
        Thread.NavMesh.NodeDistance = 1;
    }
}
