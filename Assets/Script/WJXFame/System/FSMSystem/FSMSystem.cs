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

        public void Resgister(string FsmName,List<FSM> _list) {
            if (!FsmDictionay.ContainsKey(FsmName)) {
                FsmDictionay.Add(FsmName,_list);
            }
        }

        public void UnRegister(string FsmName) {
            if (FsmDictionay.ContainsKey(FsmName)) {
                FsmDictionay.Remove(FsmName);
            }
        }

        

    }
}


