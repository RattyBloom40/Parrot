using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thread {
    public class NavRequest {
        bool done;
        public bool isFinished
        {
            get
            {
                return done;
            }
        }

        NavNode start;
        NavNode end;
        NavMesh mesh;
        NavMap map;

        public NavRequest(Vector2 origin, Vector2 goal, NavMesh mesh)
        {
            start = null;
            end = null;
            foreach(NavNode n in mesh.nodes)
            {
                if (start == null || Vector2.Distance(start.position, origin) > Vector2.Distance(n.position, origin))
                    start = n;
            }
            foreach (NavNode n in mesh.nodes)
            {
                if (end == null || Vector2.Distance(end.position, goal) > Vector2.Distance(n.position, goal))
                    end = n;
            }
            //  Start is closet node to origin, End is closest node to goal

        }

        Vector2 NextPos(Vector2 currentPos) {
            map = new NavMap();

        }

        void CreateNavMap(NavNode begin, int count) {
            foreach(NavNode node in begin.adjacentNodes) {
                if (map.nodeNumbers.ContainsKey(node))
                    continue;
                
            }
        }
    }

    class NavMap {
        public Dictionary<NavNode, int> nodeNumbers = new Dictionary<NavNode, int>();
    }
}