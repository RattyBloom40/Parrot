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
    }
}