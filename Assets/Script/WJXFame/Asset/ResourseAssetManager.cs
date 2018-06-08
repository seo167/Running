using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WJX {
    //资源管理器
	public class ResourseAssetManager:MonoBehaviour{

		private class LoadingStreamingAction:UnityEvent<Texture>{}

		LoadingStreamingAction _LoadingStreamingAction;

		private static ResourseAssetManager _ResourseAssetManager;

		Dictionary<string,object> AssetDictionary;

		public static ResourseAssetManager Instace{
			get{ 
				if(_ResourseAssetManager==null){
					GameObject obj = new GameObject ("[ResourseAssetManager]");
					return obj.AddComponent<ResourseAssetManager> ();
				}

				return _ResourseAssetManager;
			}
		}

		private ResourseAssetManager(){}

		void Awake(){
			AssetDictionary = new Dictionary<string, object> ();
			_LoadingStreamingAction =new LoadingStreamingAction();
			_ResourseAssetManager = this;
		}

		#region  纯属在StreamingAssets读取图片

		public void LoadStreamingAsset(string filePath,UnityAction<Texture> _ActionCall){
			StartCoroutine (LoadingStreamingAssets(filePath,_ActionCall));
		}

		IEnumerator LoadingStreamingAssets(string Path,UnityAction<Texture> _ActionCall){

			#if UNITY_IOS
			string filePath = "file://" + Application.streamingAssetsPath + "/"+Path;
			#elif UNITY_ANDROID
			string filePath = "jar:file://" + Application.dataPath + "!/assets/"+Path;
			#else
			string filePath = Application.streamingAssetsPath + "/" + Path;
			#endif

			WWW _www=new WWW(filePath);
			yield return _www;
			Texture _texture = null;
			if (_www.isDone&&_www.error==null) {
				_texture = _www.texture;
				
			} else {
				print ("路径错误或资源不存在");
			}

			if(_ActionCall!=null){
				_LoadingStreamingAction.AddListener(_ActionCall);
				_LoadingStreamingAction.Invoke (_texture);
				_LoadingStreamingAction.RemoveListener (_ActionCall);
			}	

			_www.Dispose ();

		}

		#endregion

		/// <summary>
		/// Loads the asset bundle.
		/// </summary>
		/// <param name="AssetBundlePath">AssetBundle.u3d地址</param>
		/// <param name="_ActionCall">加载完成后要执行的命令</param>

		public void LoadAssetBundle(string AssetBundlePath,UnityAction _ActionCall=null){
			StartCoroutine (_LoadAssetBundle(AssetBundlePath,_ActionCall));
		}
		
		Queue<AssetBundle> BundleQueue=new Queue<AssetBundle>();
		IEnumerator _LoadAssetBundle(string AssetBundlePath,UnityAction _ActionCall=null){
			#if UNITY_IOS
			string filePath = "file://" + Application.streamingAssetsPath + "/AssetBundle/IOS/IOS";
			#elif UNITY_ANDROID
			string filePath = "jar:file://" + Application.dataPath + "!/assets/AssetBundle/Android/Android";
			#else
			string filePath = Application.streamingAssetsPath + "/AssetBundle/PC/PC";
			#endif

			WWW _www = new WWW (filePath);
			yield return _www;
			if (_www.isDone && _www.error == null) {
				AssetBundle manifestLoader=_www.assetBundle;
				AssetBundleManifest manifest = manifestLoader.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
				string[] temp = manifest.GetAllDependencies (AssetBundlePath);
				for (int i = 0; i < temp.Length; ++i) {
					yield return StartCoroutine (GetManifestAsset (temp [i]));
				}

				manifestLoader.Unload (true);
			} else {
				Debug.Log ("不存在该资源,"+filePath);
			}

			_ActionCall.Invoke ();

		}

		
		//正式获取资源 
			IEnumerator GetManifestAsset(string ManifestPath){
			#if UNITY_IOS
			string filePath = "file://" + Application.streamingAssetsPath + "/AssetBundle/IOS/"+ManifestPath;
			#elif UNITY_ANDROID
			string filePath = "jar:file://" + Application.dataPath + "!/assets/AssetBundle/Android/"+ManifestPath;
			#else
			string filePath = Application.streamingAssetsPath + "/AssetBundle/PC/"+ManifestPath;
			#endif

			WWW _www = new WWW (filePath);
			yield return _www;

			if (_www.isDone && _www.error == null) {
				AssetBundle manifestLoader=_www.assetBundle;
				BundleQueue.Enqueue (manifestLoader);
				for (int i = 0; i < manifestLoader.GetAllAssetNames().Length; ++i) {
					#if UNITY_EDITOR
						Debug.Log (manifestLoader.GetAllAssetNames()[i]);
					#endif
					AssetDictionary.Add (manifestLoader.GetAllAssetNames()[i],manifestLoader.LoadAsset(manifestLoader.GetAllAssetNames()[i]));
					ResClac.AddResNum ();	
				}
				manifestLoader.Unload (false);
			}

		}
		
		public object GetDictionary(string objKey){
			if(AssetDictionary.ContainsKey(objKey)){
			return AssetDictionary[objKey];
			}
			return null;
		}
		
		//根据短字符获取对象
		public object GetDictionaryForField(string fieldkEY){
			foreach(var t in AssetDictionary.Keys){
				if(t.Contains(fieldkEY.ToLower())){
					return AssetDictionary[t];
				}
			}
			return null;
		}

		public void Clear(){
			Debug.Log ("清除数据");
			AssetDictionary.Clear ();

//			while(BundleQueue.Count>0){
//				BundleQueue.Dequeue ().Unload (true);
//			}
		}

    }
}


