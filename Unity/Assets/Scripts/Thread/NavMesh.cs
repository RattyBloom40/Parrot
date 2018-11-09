using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thread {
    public class NavMesh {
        public static float NodeDistance;
        public List<NavNode> nodes;
        public GameObject gameObject;

        public NavMesh(Vector2 originPos, GameObject obj)
        {
            gameObject = obj;
            nodes = new List<NavNode>();
        }

        public void createAdjacentNodes(NavNode origin)
        {

        }
    }
}