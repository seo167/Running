using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class LoadFJson<JsonType>:LoadAsset<JsonType>{

        //传入读取地址
        public override void LoadObjectResource(string path){
            TextAsset _path = Resources.Load<TextAsset>(path);
            JsonType _GetJson = JsonUtility.FromJson<JsonType>(_path.text);

            if (ObjectDictionary.ContainsKey(path)) {
                return;
            }

            ObjectDictionary.Add(path,_GetJson);
        }

        

    }
}


