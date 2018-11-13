using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    Thread.NavMesh navMesh;

    void OnDrawGizmos() {
        Gizmos.color = Color.white;
        foreach(Thread.NavNode node in navMesh.nodes)
        {
            Gizmos.DrawCube(node.position, Vector3.one*.05f);
            foreach (Thread.NavNode adj in node.adjacentNodes)
                Gizmos.DrawLine(node.position, adj.position);
        }
    }
}
