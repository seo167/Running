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

        UIPool _UIPool;

        private UIManager() {
            _UIPool = new UIPool();
        }

        public void ShowUI(UIType _type) {
            _UIPool.ShowUI(_type);
        }

        public void RegisterUIView(UIType _type, UIPlane _UIPlane) {
            _UIPool.RegisterPlane(_type,_UIPlane);
        }

        public void UnRegisterUIView(UIType _type) {
            _UIPool.UnRegisterPlane(_type);
        }

        public void RegisterUIModel(UIType _type, UIModel _UIModel) {
            _UIPool.RegisterModel(_type,_UIModel);
        }

        public void UnRegisterUIModel(UIType _type) {
            _UIPool.UnRegisterModel(_type);
        }

        public UIModel GetUIModel(UIType _type) {
            return _UIPool.GetModel(_type);
        }

        public UIPlane GetUIView(UIType _type) {
            return _UIPool.GetPlane(_type);
        }

		public void UILogic(UIType _type){
            _UIPool.UILogic (_type);
		}

		public bool IsHasUI(UIType _type){
			return _UIPool.HasUI (_type);
		}

		public T GetModelForT<T>(UIType _type) where T:UIModel{

			return _UIPool.GetModelForT<T>(_type);
		}

		public T GetViewForT<T>(UIType _type) where T:UIPlane{

			return _UIPool.GetViewForT<T>(_type);
		}

        public void Clear() {
            _UIPool.Clear ();
        }
    }
}


