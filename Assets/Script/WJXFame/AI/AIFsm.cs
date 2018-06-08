using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    //AI有限状态机
    public class AIFsm{
        private Dictionary<AIState, AIStateID> _AIStateDictionary = new Dictionary<AIState, AIStateID>();

        //将状态注册入有限状态机
        public void RegisterInAIFsm(AIState _AIState,AIStateID _AIStateID) {
            if (_AIStateDictionary.ContainsKey(_AIState)) {
                Debug.LogError("已经存在该AI状态");return;
            }
            _AIStateDictionary.Add(_AIState,_AIStateID);
        }


        //将状态从AI有限状态机中移除
        public void UnRegisterForAIFsm(AIState _AIState) {
            if (!_AIStateDictionary.ContainsKey(_AIState)) {
                Debug.LogError("不存在该AI状态");return;
            }

            if (_AIState== AIState.NULLAITYPE) {
                Debug.LogError("AI Key不能为空"); return;
            }

            _AIStateDictionary.Remove(_AIState);

        }

        //移除所有AI状态
        public void ClearAllState() {
            _AIStateDictionary.Clear();
        }

        public AIStateID GetStateID(AIState _AIState) {
            if (!_AIStateDictionary.ContainsKey(_AIState)){
                Debug.Log("不存在该AI状态"); return AIStateID.NULLAIID;
            }

            return _AIStateDictionary[_AIState];
        }

    }
}


