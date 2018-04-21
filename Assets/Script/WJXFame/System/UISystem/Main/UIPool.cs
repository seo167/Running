using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class UIPool
    {

        //视图对象池
        Dictionary<UIType, UIPlane> _PlaneDictionary;

        //模型对象池
        Dictionary<UIType, UIModel> _ModelDictionary;
        Transform _CanvasTransform;

        //从Json获取UI
        LoadAsset<GetUIJson> _AssetGetUIJson;

        public UIPool()
        {
            _PlaneDictionary = new Dictionary<UIType, UIPlane>();
            _ModelDictionary = new Dictionary<UIType, UIModel>();
            _CanvasTransform = GameObject.Find(UIConfig.UICanvasTransformName).transform;

            _AssetGetUIJson = ResourseAssetManager.Instace.LoadJsonAsset<GetUIJson>(UIConfig.UIJsonPath);

            if (_AssetGetUIJson.GetObject(UIConfig.UIJsonPath) != null)
            {
                ResClac.AddResNum((ushort)(_AssetGetUIJson.GetObject(UIConfig.UIJsonPath)._uiJson.Length));
                IniteUI();
            }
        }

        //初始化创建UI界面
        void IniteUI()
        {
            GetUIJson _GetUIJson = _AssetGetUIJson.GetObject(UIConfig.UIJsonPath);

            int UICount = _GetUIJson._uiJson.Length;

            for (int i = 0; i < UICount; ++i)
            {
                UIPlane _temp = (GameObject.Instantiate(Resources.Load(_GetUIJson._uiJson[i]._uiPath)) as GameObject).GetComponent<UIPlane>();
                _temp.transform.SetParent(_CanvasTransform, false);
                _PlaneDictionary.Add(_GetUIJson._uiJson[i]._uiType, _temp);
                ResClac.MinUsResNum();//每加入一个UI，引用计数器减一
            }
        }

        public void Clear()
        {
            _PlaneDictionary.Clear();
            _ModelDictionary.Clear();
        }

        /// <summary>
        /// 显示UI
        /// </summary>
        /// <param name="_type"></param>
        public void ShowUI(UIType _type)
        {
            UIPlane _uiPlane = _PlaneDictionary.TryGet(_type);
            if (_uiPlane != null)
            {
                _uiPlane.Begin();
            }
        }

        public void RegisterPlane(UIType _type, UIPlane _UIPlane)
        {
            if (_PlaneDictionary.ContainsKey(_type))
            {
                return;
            }

            _PlaneDictionary.Add(_type, _UIPlane);

        }

        public void UnRegisterPlane(UIType _type)
        {
            if (!_PlaneDictionary.ContainsKey(_type))
            {
                return;
            }

            _PlaneDictionary.Remove(_type);
            _PlaneDictionary[_type] = null;
        }

        public void RegisterModel(UIType _type, UIModel _UIModel)
        {
            if (_ModelDictionary.ContainsKey(_type))
            {
                return;
            }

            _ModelDictionary.Add(_type, _UIModel);
        }

        public void UnRegisterModel(UIType _type)
        {
            if (!_ModelDictionary.ContainsKey(_type))
            {
                return;
            }

            _ModelDictionary.Remove(_type);
            _ModelDictionary[_type] = null;
        }

        public UIPlane GetPlane(UIType _type)
        {
            if (!_PlaneDictionary.ContainsKey(_type))
            {
                return null;
            }

            return _PlaneDictionary[_type];
        }

        public T GetViewForT<T>(UIType _type) where T : UIPlane
        {
            if (!_PlaneDictionary.ContainsKey(_type))
            {
                return null;
            }

            return _PlaneDictionary[_type] as T;
        }

        public UIModel GetModel(UIType _type)
        {
            if (!_ModelDictionary.ContainsKey(_type))
            {
                return null;
            }

            return _ModelDictionary[_type];
        }

        public void UILogic(UIType _type)
        {
            if (!_PlaneDictionary.ContainsKey(_type))
            {
                return;
            }

            _PlaneDictionary[_type].Logic();

        }

        public T GetModelForT<T>(UIType _type) where T : UIModel
        {
            if (!_ModelDictionary.ContainsKey(_type))
            {
                return null;
            }
            return _ModelDictionary[_type] as T;
        }

        public bool HasUI(UIType _type)
        {
            return _PlaneDictionary.ContainsKey(_type);
        }

    }
}


