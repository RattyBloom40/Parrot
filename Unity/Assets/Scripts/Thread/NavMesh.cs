using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thread {
    public class NavMesh {
        public static float NodeDistance = 1;
        public List<NavNode> nodes;
        public GameObject gameObject;

        public NavMesh(Vector2 originPos, GameObject obj)
        {
            gameObject = obj;
            nodes = new List<NavNode>();
            NavNode nodeZero = new NavNode(originPos);
            nodes.Add(nodeZero);
            createAdjacentNodes(nodeZero);
            foreach(NavNode node in nodes)
            {
                foreach(NavNode adj in nodes)
                    if(Vector2.Distance(node.position,adj.position)==1)
                    {
                        node.adjacentNodes.Add(adj);
                        adj.adjacentNodes.Add(node);
                    }
            }
        }

        public void createAdjacentNodes(NavNode origin)
        {
            if(!Physics.Raycast(origin.position,Vector2.up,NodeDistance))
            {
                NavNode node = new NavNode(origin.position + Vector2.up * NodeDistance);
                nodes.Add(node);
            }
            if (!Physics.Raycast(origin.position, Vector2.down, NodeDistance))
            {
                NavNode node = new NavNode(origin.position + Vector2.down * NodeDistance);
                nodes.Add(node);
            }
            if (!Physics.Raycast(origin.position, Vector2.left, NodeDistance))
            {
                NavNode node = new NavNode(origin.position + Vector2.left * NodeDistance);
                nodes.Add(node);
            }
            if (!Physics.Raycast(origin.position, Vector2.right, NodeDistance))
            {
                NavNode node = new NavNode(origin.position + Vector2.right * NodeDistance);
                nodes.Add(node);
            }
        }
    }
}