using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    //读取AssetBundle会从AssetStreaming中获取
    public class LoadAssetBundle : LoadAsset<object> {
        Queue<AssetBundle> _AssetBundleQueue;

        string _AssetBundleName;

        public string SetAssetBundleName {
            set {
                _AssetBundleName = value;
            }
        }

        //加载间隔
        float ProgressOffset=0.0f;

        ushort StatisticsCount=0;

        public LoadAssetBundle() {
            _AssetBundleQueue = new Queue<AssetBundle>();
           
        }

        public override void LoadObjectResource(string path) {
        #if UNITY_IOS
			string filePath = "file://" + Application.streamingAssetsPath + "/AssetBundle/IOS/"+path;
        #elif UNITY_ANDROID
			string filePath = "jar:file://" + Application.dataPath + "!/assets/AssetBundle/Android/"+path;
        #else
            string AssetPath = Application.streamingAssetsPath + "/" + path;
        #endif
          //  BundleLoadFromFile(AssetPath);
        }

        //正常读取AssetBundle
        void BundleLoadFromFile(string Path) {
            AssetBundle ab = AssetBundle.LoadFromFile(Path);

            if (ab==null) {
                Debug.LogError("不存在该AB包");
                return;
            }

            ab.Unload(false);
            //存储入队列
            _AssetBundleQueue.Enqueue(ab);

            AssetBundleManifest abm = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
           
            LoadManifestBundle(abm);
        }

        void LoadManifestBundle(AssetBundleManifest abm) {
            string[] bundleName = abm.GetAllDependencies(_AssetBundleName);

            //获取有多少个依赖包
            StatisticsCount = (ushort)bundleName.Length;
            //计算间隔
            ProgressOffset = (1 / StatisticsCount);
            for (int i = 0; i < bundleName.Length; ++i){
                //载入依赖包
                AssetBundle ab = AssetBundle.LoadFromFile(bundleName[i]);
                ab.Unload(false);
                _AssetBundleQueue.Enqueue(ab);
                for (int j=0;j<ab.AllAssetNames().Length;++j) {
                    string key = ab.AllAssetNames()[j];
                    ObjectDictionary.Add(key,ab.LoadAsset(key));
                    ResClac.AddResNum();//引用加一
                }
            }
        }

        //清空全部对象
        public override void ObjectClear(){
            //置空对象池
            ObjectDictionary.Clear();

            for (;_AssetBundleQueue.Count>0;) {
                _AssetBundleQueue.Dequeue().Unload(true);
            }
        }

    }
}


