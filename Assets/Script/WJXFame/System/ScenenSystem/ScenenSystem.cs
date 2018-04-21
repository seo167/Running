using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class ScenenSystem : MonoBehaviour{

		bool CanRun=false;

		private static ScenenSystem _ScenenSystem;

		public static ScenenSystem Instace {
            get {
                return _ScenenSystem;
            }
        }

        void Awake() {

			if(_ScenenSystem != null){
				return;
			}

            _ScenenSystem = this;
            DontDestroyOnLoad(this.gameObject);
			ScenenController.ChangeScenenState(new GameScenen());
        }

        void Start() {
            ScenenController.GetScenenState().ScenenStart();
        }

        void Update() {
            ScenenController.GetScenenState().ScenenLogic();
        }

		public void ChangeScenenState(ScenenState _ScenenState) {
			CanRun = false;
			ScenenController.ChangeScenenState (_ScenenState);
		}

		public void Clear(){
			ScenenController.GetScenenState().ScenenEnd();
		}

		public void ScenenStart(){
			CanRun = true;
			ScenenController.GetScenenState().ScenenStart();

		}
    }
}


