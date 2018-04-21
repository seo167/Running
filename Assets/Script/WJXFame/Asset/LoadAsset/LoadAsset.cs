using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    //资源读取父类
    public class LoadAsset<AssetType>{

       protected Dictionary<string, AssetType> ObjectDictionary = new Dictionary<string, AssetType>();

        //加载进度
        protected float Progress;

        public float GetProgress {
            get {
                return Progress;
            }
        }

        //获取资源对象
        public AssetType GetObject(string key) {
            if (ObjectDictionary.ContainsKey(key)) {
                return ObjectDictionary[key];
            }
            return default(AssetType);
        }

        //传入读取地址
        public virtual void LoadObjectResource(string path) {
            //..........
        }

        //清空资源
        public virtual void ObjectClear() {
            //.........
        }

    }
}

