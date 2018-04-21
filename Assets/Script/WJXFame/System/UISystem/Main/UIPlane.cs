using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class UIPlane : MonoBehaviour{

        protected virtual void Awake() { }

        public virtual void Enable() {
            //UI视图显示时逻辑
        }

        public virtual void Begin() {
            //UI视图开始时逻辑
        }

        public virtual void Pause() {
            //UI视图暂停逻辑
        }

        public virtual void Disable() {
            //UI视图隐藏后逻辑
        }

        public virtual void Logic() {
            //UI视图逻辑
        }
    }
}


