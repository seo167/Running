using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public static class ScenenController
    {
        private static ScenenState _ScenenState;

        public static void ChangeScenenState(ScenenState scenenState) {
            _ScenenState = null;
            _ScenenState = scenenState;
        }

        public static ScenenState GetScenenState() {
            if (_ScenenState==null) {
                _ScenenState = new ScenenState();
            }

            return _ScenenState;
        }
    }
}


