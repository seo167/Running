using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    //资源管理器
    public class ResourseAssetManager{
        LoadAsset<object> AssetBundleLoad;
       	
		LoadAsset<object> LoadFAssetStream;

        //LoadAsset StreamingLoad;

        static private ResourseAssetManager _ResourseAssetManager;

        static public ResourseAssetManager Instace {
            get {
                if (_ResourseAssetManager==null) {
                    _ResourseAssetManager = new ResourseAssetManager();
                }
                return _ResourseAssetManager;
            }
        }

        private ResourseAssetManager(){

        }

        public void SetAssetBundleName(string AssetBundleName) {
            
        }

		public void LoadFromFileFAssetStream(string path){
			LoadFAssetStream.LoadObjectResource (path);
		}

        public LoadAsset<JsonType> LoadJsonAsset<JsonType>(string path) {
            LoadAsset<JsonType> JsonLoad=new LoadAsset<JsonType>();

            JsonLoad.LoadObjectResource(path);

            return JsonLoad;
        }

    }
}


