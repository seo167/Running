using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class AIStates{
        //用来存储AITypeID先后需要执行的顺序
        private List<AIStateID> _AIStateIDList = new List<AIStateID>();

		//正式返回AIID
		private Queue<AIStateID> _AIStateIDQueue=new Queue<AIStateID>();

		public AIStateID AIStateIDQueue{
			get{ 
				if(_AIStateIDQueue.Count<=0){
					foreach(var t in _AIStateIDList){
						_AIStateIDQueue.Enqueue (t);
					}
				}
				return _AIStateIDQueue.Dequeue ();
			}
		}

		private AIStateID _MyAIStateID;

        public AIStateID GetAIStateID {
            get {
                return _MyAIStateID;
            }
        }

        public AIStates(AIStateID mAIStateID) {
            _MyAIStateID = mAIStateID;
        }


        public virtual void IniteState() {
            //初始化状态
        }

        public virtual void StartState() {
            //开始状态
        }

        public virtual void StateExcue(GameObject _obj=null) {
            //行动状态
        }

        public virtual void ExitState() {
            //退出状态
        }

        //添加状态
        public void AddState(AIStateID _StateID) {
            //判断该状态是否已经存在链表
            if (_AIStateIDList.Contains(_StateID)) {
                Debug.LogError("状态已经存在该链表，请删除再添加");return;
            }

            _AIStateIDList.Add(_StateID);
			_AIStateIDQueue.Enqueue (_StateID);

        }

		//删除状态(不会删除到队列的ID)
        public void RemoveState(AIStateID _StateID) {
            //判断该状态是否已经存在链表
            if (!_AIStateIDList.Contains(_StateID)){
                Debug.LogError("状态不存在该链表"); return;
            }
            _AIStateIDList.Remove(_StateID);

        }

        //清空全部状态
        public void ClearAllState() {
            _AIStateIDList.Clear();
        }

        //判断自身是否拥有该状态
        public bool JudgeState(AIStateID _AIStateID) {
            for (int i=0;i< _AIStateIDList.Count;++i) {
                if (_AIStateIDList.Contains(_AIStateID)) {
                    return true;
                }
            }
            return false;
        }

    }
}


