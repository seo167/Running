using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using WJX;

//获取指定文件夹下的资源
public class LoadFAssetStream : LoadAsset<object> {

	void LoadFromFile(string path){
		Debug.Log (path);
		if (Directory.Exists(path)){  
			DirectoryInfo direction = new DirectoryInfo(path);  
			FileInfo[] files = direction.GetFiles("*",SearchOption.AllDirectories);  

			Debug.Log(files.Length+",+++++++++++++++++");  

			for(int i=0;i<files.Length;i++){  
				if (files[i].Name.EndsWith(".meta")){  
					continue;  
				}  
				Debug.Log( "Name:" + files[i].Name );  
			}  
		}  
	}

	//传入读取地址
	public override void LoadObjectResource(string path) {

		if(path.Equals("")){
			return;
		}

		#if UNITY_IOS
		string filePath = Application.streamingAssetsPath + "/"+path;
		#elif UNITY_ANDROID
		string filePath = Application.dataPath + "!/assets/"+path;
		#else
		string filePath = Application.streamingAssetsPath + "/" + path;
		#endif

		LoadFromFile (filePath);

	}

	//清空资源
	public override void ObjectClear() {
		
	}

	
	
}
