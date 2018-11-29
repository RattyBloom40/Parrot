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

        public NavRequest(Vector2 origin, Vector2 goal, NavMesh mesh)
        {
            NavMap map = new NavMap();
            NavNode start = null;
            NavNode end = null;
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

        //NavNode CreateNodeOrder() {
            
        //}
    }

    class NavMap {
        Dictionary<NavNode, int> nodeNumbers = new Dictionary<NavNode, int>();
    }
}