using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {

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

		Dictionary<UIType,UIController> UIControllerDictionary;

        private UIManager() {
			UIControllerDictionary =new Dictionary<UIType,UIController> ();
        }

		//注册控制器
		public void RegisterController(UIType type,UIController controller){
			if(UIControllerDictionary.ContainsKey(type)){
				if(UIControllerDictionary[type]==null){
					UIControllerDictionary [type] = controller;
				}
				return;
			}

			UIControllerDictionary.Add (type,controller);

		}

		/// <summary>
		/// 执行Controller逻辑
		/// </summary>
		/// <param name="_type">Type.</param>
		public void UILogic(UIType _type){
			if(UIControllerDictionary.ContainsKey(_type)){
				UIControllerDictionary [_type].ControllerLogic();
			}
		}
			

		/// <summary>
		/// 获取Conteroller
		/// </summary>
		/// <returns>The controller for t.</returns>
		/// <param name="_type">Type.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T GetControllerForT<T>(UIType _type) where T:UIController{
			if(UIControllerDictionary.ContainsKey(_type)){
				return (T)UIControllerDictionary [_type];
			}
			return null;
		}

        public void Clear() {
			UIControllerDictionary.Clear ();
        }
    }
}