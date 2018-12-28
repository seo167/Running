using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farmework
{
    public class UIManager
    {
        private static UIManager _uiManager;

        public static UIManager Instace{
            get {
                if (_uiManager==null) {
                    _uiManager = new UIManager();
                }

                return _uiManager;
            }
        }

        static private Dictionary<string, UIPlane> UIDictionary=new Dictionary<string, UIPlane>();

        //创建UI
        public UIPlane Create(string UIName) {
            var UI = Resources.Load<UIPlane>(UIName);
            UI = Object.Instantiate<UIPlane>(UI);
            return UI;
        }

        public void SavePlane(string UIName,UIPlane plane) {
            UIDictionary.Add(UIName,plane);
        }

        public UIPlane GetPlane(string UIName) {
            return UIDictionary[UIName];
        }

        public void DeletePlane(string UIName) {
            if (UIDictionary.ContainsKey(UIName)) {
                UIDictionary.Remove(UIName);
            }
        }

        void Clear() {
            UIDictionary.Clear();
        }

    }
}


