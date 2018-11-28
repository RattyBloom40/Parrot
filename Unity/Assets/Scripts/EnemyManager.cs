using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    Thread.NavMesh navMesh;

    public Vector2 navOrigin;

    void Awake()
    {
        navMesh = new Thread.NavMesh(navOrigin, gameObject);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.white;
        if (navMesh!=null)
            foreach (Thread.NavNode node in navMesh.nodes)
            {
                Gizmos.DrawCube(node.position, Vector3.one * .5f);
                foreach (Thread.NavNode adj in node.adjacentNodes)
                    Gizmos.DrawLine(node.position, adj.position);
            }
    }
}
