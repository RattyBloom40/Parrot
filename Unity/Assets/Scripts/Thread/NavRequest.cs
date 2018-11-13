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

        }
    }

    class NavMap {
        Dictionary<NavNode, int> nodeNumbers = new Dictionary<NavNode, int>();
    }
}