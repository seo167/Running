using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {

	public enum AISystemEnum{
		USEQUEUE,
		NOTUSEQUEUE
	}

    public class AISystem{
        Dictionary<AIStateID, AIStates> _AIStateS = new Dictionary<AIStateID, AIStates>();
        AIFsm _AIFSM;

        public AISystem() {
            _AIFSM = new AIFsm();
        }

        public void RegisterAIstates(AIState _AIState,AIStates _AIStates) {

            if (_AIStates==null) {
                return;
            }

            if (_AIStateS.ContainsKey(_AIStates.GetAIStateID)) {
                Debug.LogError("已经存在该AI状态");return;
            }
			_AIStateS.Add (_AIStates.GetAIStateID,_AIStates);
            _AIFSM.RegisterInAIFsm(_AIState,_AIStates.GetAIStateID);
            
        }

		/// <summary>
		/// Pushs the AII.
		/// </summary>
		/// <param name="_AIState">AI state.</param>
		/// <param name="_SaveStateID">需要存入序列的目标ID</param>
		public void PushAIID(AIState _AIState,AIStateID _SaveStateID){
			if(_AIStateS.ContainsKey(_AIFSM.GetStateID(_AIState))){
				_AIStateS [_AIFSM.GetStateID (_AIState)].AddState (_SaveStateID);
			}
		}

		//初始化状态
		public void IniteState(AIState _AIState){
			if(_AIFSM.GetStateID(_AIState)==AIStateID.NULLAIID){
				return;
			}

			if(_AIStateS.ContainsKey(_AIFSM.GetStateID(_AIState))){
				_AIStateS [_AIFSM.GetStateID (_AIState)].IniteState ();
			}
		}


		//开始状态
		public void StartState(AIState _AIState){
			if(_AIFSM.GetStateID(_AIState)==AIStateID.NULLAIID){
				return;
			}

			if(_AIStateS.ContainsKey(_AIFSM.GetStateID(_AIState))){
				_AIStateS [_AIFSM.GetStateID (_AIState)].StartState();
			}
		}

		//状态执行
		public void StateExcue(AIState _AIState, GameObject _obj=null,AISystemEnum _AISYSTEMENUM=AISystemEnum.NOTUSEQUEUE) {
			if(_AIFSM.GetStateID(_AIState)==AIStateID.NULLAIID){
				return;
			}

			if(_AIStateS.ContainsKey(_AIFSM.GetStateID(_AIState))){
				if (_AISYSTEMENUM == AISystemEnum.NOTUSEQUEUE) {
					_AIStateS [_AIFSM.GetStateID (_AIState)].StateExcue (_obj);
				} else {
					AIStates temp = _AIStateS [_AIFSM.GetStateID (_AIState)];
					AIStateID _id = temp.AIStateIDQueue;
					_AIStateS [_id].StateExcue (_obj);
				}

			}
        }

		//退出状态
		public void ExitState(AIState _AIState){
			if(_AIFSM.GetStateID(_AIState)==AIStateID.NULLAIID){
				return;
			}

			if(_AIStateS.ContainsKey(_AIFSM.GetStateID(_AIState))){
				_AIStateS [_AIFSM.GetStateID (_AIState)].ExitState ();
			}
		}

    }
}

