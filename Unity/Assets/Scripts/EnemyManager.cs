using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public Thread.NavMesh navMesh;


    public static EnemyManager eManager;

    public Vector2 navOrigin;

    void Awake()
    {
        if (eManager == null)
            eManager = this;
        else
            Debug.Log("Error: 2 EnemyManagers active");
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
