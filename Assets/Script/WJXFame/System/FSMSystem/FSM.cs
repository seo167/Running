using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    //状态机
    public abstract class FSM{
        protected GameObject _obj;//需要绑定的对象

        short _ID;

        public short GetID{
            get{
                return _ID;
            }
        }

        protected FSM _Next;//下一个节点,主要用来判断是否可以切换到下一个状态
        protected FSM _Prev;//上一个节点,主要用来判断是否可以切换到上一个状态

        public FSM Next{
            get{
                return _Next;
            }
        }

        public FSM Prev{
            get{
                return _Prev;
            }
        }

        public void SetNext(FSM Next){
            _Next = Next;
        }

        public void SetPrev(FSM Prev){
            _Prev = Prev;
        }

        public FSM(GameObject obj){
            _obj = obj;
        }

        public FSM(short id,GameObject obj){
            _ID = id;
            _obj = obj;
        }

        public FSM(string name,short id,GameObject obj){
            _ID = id;
            _obj = obj;
            FSMSystem.Instace.Resgister(name, this);
        }

        //状态机逻辑
        public abstract void FsmLogic();
    }
}


