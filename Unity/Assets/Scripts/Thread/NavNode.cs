using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thread {
    public class NavNode {
        public Vector2 position;
        public List<NavNode> adjacentNodes;

        public NavNode(Vector2 pos)
        {
            adjacentNodes = new List<NavNode>();
            position = pos;
        }
    }
}