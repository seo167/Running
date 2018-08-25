using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class FSMSystem{

        private static FSMSystem _FSMSystem;

        public static FSMSystem Instace{
            get{
                if (_FSMSystem == null){
                    _FSMSystem = new FSMSystem();
                }
                return _FSMSystem;
            }
        }

        //状态机存储器
        Dictionary<string, List<FSM>> FsmDictionay;

        private FSMSystem() {
            FsmDictionay = new Dictionary<string, List<FSM>>();
        }

        //注册状态列表
        public void Resgister(string FsmName,FSM _fsm) {
            if (!FsmDictionay.ContainsKey(FsmName)) {
                List<FSM> _list = new List<FSM>();
                FsmDictionay.Add(FsmName,_list);
            }

            if(!FsmDictionay[FsmName].Contains(_fsm))
                FsmDictionay[FsmName].Add(_fsm);
        }

        public void UnRegister(string FsmName) {
            if (FsmDictionay.ContainsKey(FsmName)) {
                FsmDictionay.Remove(FsmName);
            }
        }

        public FSM GetFSM(string FsmName,int num){
            if(FsmDictionay.ContainsKey(FsmName)){
                return FsmDictionay[FsmName][num];
            }
            return null;
        }
    }
}


