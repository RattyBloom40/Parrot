using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thread {
    public class NavMesh {
        public static float NodeDistance = 2f;
        public List<NavNode> nodes;
        public GameObject gameObject;
        public bool baked = false;

        public NavMesh(Vector2 originPos, GameObject obj) {
            gameObject = obj;
            nodes = new List<NavNode>();
            NavNode nodeZero = new NavNode(originPos);
            nodes.Add(nodeZero);
            PlayerController.player.StartCoroutine(createAdjacentNodes(nodeZero, 0));
            Debug.Log("NavMesh baked");
            foreach (NavNode node in nodes) {
                foreach (NavNode adj in nodes)
                    if (Vector2.Distance(node.position, adj.position) == NodeDistance) {
                        node.adjacentNodes.Add(adj);
                        adj.adjacentNodes.Add(node);
                    }
            }
            baked = true;
        }

        public NavNode GetNode(Vector2 pos) {
            foreach (NavNode node in nodes)
                if (node.position.Equals(pos))
                    return node;
            return null;
        }

        public IEnumerator createAdjacentNodes(NavNode origin, int count) {
            Debug.Log("Count: " + count+"\n"+origin.position.x+", "+origin.position.y);
            if (count > 3)
                return null;
            if (Physics2D.Raycast(origin.position, Vector2.up, NodeDistance).collider == null) {
                NavNode node = new NavNode(origin.position + Vector2.up * NodeDistance);
                bool repeat = false;
                foreach (NavNode n in nodes)
                    if (n.position == node.position)
                        repeat = true;
                if (!repeat) {
                    nodes.Add(node);
                    createAdjacentNodes(node, count + 1);
                }
            }
            if (Physics2D.Raycast(origin.position, Vector2.down, NodeDistance).collider == null) {
                NavNode node = new NavNode(origin.position + Vector2.down * NodeDistance);
                bool repeat = false;
                foreach (NavNode n in nodes)
                    if (n.position == node.position)
                        repeat = true;
                if (!repeat) {
                    nodes.Add(node);
                    createAdjacentNodes(node, count + 1);
                }
            }
            if (Physics2D.Raycast(origin.position, Vector2.left, NodeDistance).collider == null) {
                NavNode node = new NavNode(origin.position + Vector2.left * NodeDistance);
                bool repeat = false;
                foreach (NavNode n in nodes)
                    if (n.position == node.position)
                        repeat = true;
                if (!repeat) {
                    nodes.Add(node);
                    createAdjacentNodes(node, count + 1);
                }
            }
            if (Physics2D.Raycast(origin.position, Vector2.right, NodeDistance).collider == null) {
                NavNode node = new NavNode(origin.position + Vector2.right * NodeDistance);
                bool repeat = false;
                foreach (NavNode n in nodes)
                    if (n.position == node.position)
                        repeat = true;
                if (!repeat) {
                    nodes.Add(node);
                    createAdjacentNodes(node, count + 1);
                }
            }
            return null;
        }
    }
}