using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace WJX {
   
    public class UIPlane : MonoBehaviour{
		
		protected virtual void Awake() {
			//用于初始化
        }

		public virtual void OnEnter(UnityAction _Action=null){
			//UI视图显示时逻辑
		}

		public virtual void Begin(UnityAction _Action=null) {
            //UI视图开始时逻辑
        }

		public virtual void Pause(UnityAction _Action=null) {
            //UI视图暂停逻辑
        }

		public virtual void Logic(UnityAction _Action=null) {
            //UI视图逻辑
        }

		public virtual void OnExit(UnityAction _Action=null){
			//UI视图隐藏逻辑
		}
    }
}


