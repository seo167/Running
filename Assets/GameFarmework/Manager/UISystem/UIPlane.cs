using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farmework
{
    public class UIPlane : MonoBehaviourSimply{
        protected string UIName;

        private void Awake(){
            Init();
            RegisterMsg(UIName, (object _oject) =>Logic(_oject));
            UIManager.Instace.SavePlane(UIName,this);
        }

        protected virtual void Init() {
            //UI视图初始化时逻辑
        }

        public virtual void Reset() {
            //UI状态重置
        }

        protected virtual void Logic(object _oject){
            //UI视图逻辑
        }

        protected override void OnBeforeDestroy() {
            UIManager.Instace.DeletePlane(UIName);
        }

        private void OnDisable(){
            Reset();
        }

    }
}


