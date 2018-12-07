using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thread {
    public class NavRequest {
        public enum State{
            Pathfind,
            GetToEnd
        }

        State state;

        bool done;
        public bool isFinished {
            get {
                return done;
            }
        }

        NavNode start;
        NavNode end;
        NavMesh mesh;
        NavMap map;

        public NavRequest(Vector2 origin, Vector2 goal, NavMesh mesh) {
            start = null;
            end = null;
            state = State.Pathfind;
            foreach (NavNode n in mesh.nodes) {
                if (start == null || Vector2.Distance(start.position, origin) > Vector2.Distance(n.position, origin))
                    start = n;
            }
            foreach (NavNode n in mesh.nodes) {
                if (end == null || Vector2.Distance(end.position, goal) > Vector2.Distance(n.position, goal))
                    end = n;
            }
            //  Start is closet node to origin, End is closest node to goal

        }

        Vector2 NextPos(Vector2 currentPos) {
            map = new NavMap();
            BuildNavMap(start,0);
            NavNode[] array = new NavNode[1];
            array[0] = start;
            return BuildPath(array)[0].position;
        }

        NavNode[] BuildPath(NavNode[] current) {
            NavNode newClosest = null;
            foreach(NavNode node in current[0].adjacentNodes) {
                if (newClosest == null)
                    newClosest = node;
                else {
                    int x, y;
                    map.nodeNumbers.TryGetValue(node, out x);
                    map.nodeNumbers.TryGetValue(newClosest, out y);
                    if (x < y)
                        newClosest = node;
                }
            }
            NavNode[] final = new NavNode[current.Length + 1];
            final[0] = newClosest;
            for(int x = 0;x<current.Length;x++) {
                final[x + 1] = current[x];
            }
            if (newClosest.Equals(end))
                return final;
            else
                return BuildPath(final);
        }

        void BuildNavMap(NavNode begin, int count) {
            map.nodeNumbers.Add(begin, count);
            if (begin.Equals(end))
                return;
            foreach (NavNode node in begin.adjacentNodes) {
                if (map.nodeNumbers.ContainsKey(node))
                    continue;
                BuildNavMap(node, count + 1);
            }
        }
    }

    class NavMap {
        public Dictionary<NavNode, int> nodeNumbers = new Dictionary<NavNode, int>();
    }
}