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
            createAdjacentNodes(nodeZero, 0);
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
        
        public void createAdjacentNodes(NavNode origin, int count)
        {
            if (count > 25)
                return;
            bool up = true;
            bool down = true;
            bool left = true;
            bool right = true;
            foreach (NavNode adj in nodes)
                if (Vector2.Distance(origin.position, adj.position) == NodeDistance)
                {
                    if (adj.position.y > origin.position.y)
                        up = false;
                    if (adj.position.y < origin.position.y)
                        down = false;
                    if (adj.position.x > origin.position.x)
                        right = false;
                    if (adj.position.x < origin.position.y)
                        left = false;
                }
            if (up&&Physics2D.Raycast(origin.position,Vector2.up,NodeDistance).collider==null)
            {
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
            return;
        }
    }
}