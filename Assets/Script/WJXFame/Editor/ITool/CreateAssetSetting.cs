using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WJX;
using System.IO;
using System.Collections.Generic;

public class CreateAssetSetting{

	//设置assetstreaming资源路径
	[MenuItem("Itools/CreateAssetStreamingSetting(设置AssetStreaming资源路径)")]
	static void SetObjAssetStreamingSetting(){
		object[] gameObjects;  
		gameObjects = GameObject.FindSceneObjectsOfType (typeof(GameObject));
		string ScenenName=SceneManager.GetActiveScene().name;
		for(int i=0;i<gameObjects.Length;++i){
			GameObject temp = gameObjects [i] as GameObject;

			if(temp.GetComponent<Image>()!=null){
				
				Image ImageTemp = temp.GetComponent<Image> ();

				if(ImageTemp.sprite!=null){
					
					string name = ScenenName +"/"+ ImageTemp.sprite.name+".png";
					temp.AddComponent<AssetInite> ();
					temp.GetComponent<AssetInite> ().SetAsset (name);
				}


				continue;
			}

			if(temp.GetComponent<SpriteRenderer>()!=null){
				SpriteRenderer SpriteRendererTemp = temp.GetComponent<SpriteRenderer> ();
				if(SpriteRendererTemp.sprite!=null){
					string name = ScenenName+"/"+SpriteRendererTemp.sprite.name+".png";
					temp.AddComponent<AssetInite> ();
					temp.GetComponent<AssetInite> ().SetAsset (name);
				}

				continue;
			}

		}
	}

	//设置AssetBundle资源路径
	[MenuItem("Itools/AssetBundleSetting(设置AssetBundel资源路径)")]
	static void AssetBundleSetting(){
		
		string ScenenName=SceneManager.GetActiveScene().name;

		string pathName=ScenenName.ToLower()+".u3d.manifest";

		#region 获取AssetBundleManifest文件入面的资源文件路径

		string[] temp = File.ReadAllLines( Application.streamingAssetsPath + "/AssetBundle/IOS/"+pathName);
		List<string> tempList = new List<string> ();

		for(int i=14;i<temp.Length;++i){
			string[] FileTemp = File.ReadAllLines (temp[i].Substring(temp[i].IndexOf("Assets"))+".manifest");
			int num = 0;
			for(int j=0;j<FileTemp.Length-1;++j){

				if(FileTemp[j].Contains("Assets:")){
					num = j;
					continue;
				}

				if(tempList.Contains(FileTemp[j])||num==0){
					continue;
				}

				tempList.Add (FileTemp[j].Substring(FileTemp[j].IndexOf("-")+2));
			}
		}
			
		#endregion

		#region 为对象设置路径

		object[] gameObjects;  
		gameObjects = GameObject.FindSceneObjectsOfType (typeof(GameObject));
		for(int i=0;i<gameObjects.Length;++i){
			GameObject objtemp = gameObjects [i] as GameObject;
			if(objtemp==null||objtemp.name.Equals("Image")){
				continue;
			}
			if(objtemp.GetComponent<Image>()!=null){

				Image ImageTemp = objtemp.GetComponent<Image> ();

				if(ImageTemp.sprite!=null){
					string name =AssetDatabase.GetAssetPath(ImageTemp.sprite);

					for(int k=0;k<tempList.Count;++k){
						
						if(tempList[k].Equals(name)){
							if(objtemp.GetComponent<AssetInite>()==null){
								objtemp.AddComponent<AssetInite> ().SetAssetBundleName (tempList[k]);
								AssetIniteEdit.Instace.AddAssetInite(objtemp.GetComponent<AssetInite>());

							}else{
								AssetIniteEdit.Instace.AddAssetInite(objtemp.GetComponent<AssetInite>());
							}
							break;
						}
					}

				}
				continue;
			}
			if(objtemp.GetComponent<SpriteRenderer>()!=null){
				SpriteRenderer SpriteRendererTemp = objtemp.GetComponent<SpriteRenderer> ();
				if(SpriteRendererTemp.sprite!=null){
					string name = AssetDatabase.GetAssetPath(SpriteRendererTemp.sprite);
					for(int k=0;k<tempList.Count;++k){
						if(tempList[k].Equals(name)){
							if(objtemp.GetComponent<AssetInite>()==null){
								objtemp.AddComponent<AssetInite> ().SetAssetBundleName (tempList[k]);
								AssetIniteEdit.Instace.AddAssetInite(objtemp.GetComponent<AssetInite>());
							}else{
								AssetIniteEdit.Instace.AddAssetInite(objtemp.GetComponent<AssetInite>());
							}
							break;
						}
					}
				}
				continue;
			}

		}
		#endregion
	}


	[MenuItem("Itools/MarkAssetTag(设置打包标签)")]
	static void MarkAssetTag(){
		string infoPath=Application.dataPath + "/Game/LevelResource/";
		SearchDirectory (infoPath,false);
	}

	//搜索文件夹下面的文件
	static void SearchDirectory(string PathName,bool isClear){
		DirectoryInfo dir = new DirectoryInfo (PathName);

		FileSystemInfo[] _FileSystemInfo = dir.GetFileSystemInfos ();

		for(int i=0;i<_FileSystemInfo.Length;++i){
			if (Directory.Exists (_FileSystemInfo [i].FullName)) {
				SearchDirectory (_FileSystemInfo [i].FullName,isClear);
			} else {
				string aFile = _FileSystemInfo [i].FullName;
				string aLastName = aFile.Substring(aFile.LastIndexOf(".") + 1, (aFile.Length - aFile.LastIndexOf(".") - 1));
				string ImageType="png/jpg/bmp/gif";
				if(ImageType.Contains(aLastName)){
					//Set the AssetBundle MarkTag
					SetAssetMark((FileInfo)_FileSystemInfo[i],isClear);

				}
			}
		}

	}

	static void SetAssetMark(FileInfo fileInfo,bool isClear){
		string fullPath = fileInfo.FullName;
		int assetCount = fullPath.IndexOf("Assets");
		string assetPath = fullPath.Substring (assetCount,fullPath.Length-assetCount);
		AssetImporter importer = AssetImporter.GetAtPath(assetPath);
		if (!isClear) {
			for(int i=0;i<3;++i){
				assetPath = assetPath.Substring (assetPath.IndexOf ("/") + 1);
			}
			importer.assetBundleName = assetPath.Substring(0,assetPath.LastIndexOf("/"));
			importer.assetBundleVariant = "ld";
		} else {
			importer.assetBundleName = "";
			importer.assetBundleVariant = "";
		}
	}

	[MenuItem("Itools/ClearAssetTag(清除打包标签)")]
	static void ClearAssetTag(){
		string infoPath=Application.dataPath + "/Game/LevelResource/";
		SearchDirectory (infoPath,true);
	}


	[MenuItem("Itools/BuildAssetBundleIOS(创建一个IOS文件夹，AssetBundle文件都放在里面)")]
	public static void BuildAssetIOSBundle()
	{
		//streamingassetpath / windows
		string outPath = Application.streamingAssetsPath + "/AssetBundle/IOS"; //Application.streamingAssetsPath +"/AssetBundle";

		BuildAssetbUNDLE(outPath);
	}

	[MenuItem("Itools/BuildAssetBundleAndroid(创建一个Android文件夹，AssetBundle文件都放在里面)")]
	public static void BuildAssetAndroidBundle()
	{
		//streamingassetpath / windows
		string outPath = Application.streamingAssetsPath + "/AssetBundle/Android"; //Application.streamingAssetsPath +"/AssetBundle";
		BuildAssetbUNDLE(outPath);

	}

	static void BuildAssetbUNDLE(string outPath){
		if (!Directory.Exists(outPath)){
			//创建文件夹
			Directory.CreateDirectory(outPath);
		}

		BuildPipeline.BuildAssetBundles(outPath, 0, EditorUserBuildSettings.activeBuildTarget);

		AssetDatabase.Refresh();
	}

	[MenuItem("Itools/SetPicture32(压缩图片为32)")]
	public static void SetPicture32(){
		SetImportTexture (32);
	}

	[MenuItem("Itools/SetPicture32(压缩图片为2048)")]
	public static void SetPicture2048(){
		SetImportTexture (2048);
	}

	static void SetImportTexture(int maxSize){
		AssetInite[] _AssetIniteArray = GameObject.FindObjectsOfType (typeof(AssetInite)) as AssetInite[];
		for(int i=0;i<_AssetIniteArray.Length;++i){
			string path = _AssetIniteArray [i].GetAssetBundlePathName;
			path = Application.dataPath +path.Substring(path.IndexOf ("/"));

			if (File.Exists (path)) {
				TextureImporter texImporter = AssetImporter.GetAtPath(_AssetIniteArray [i].GetAssetBundlePathName) as TextureImporter;

				if(texImporter==null){
					Debug.Log (_AssetIniteArray [i].GetAssetBundlePathName);
					continue;
				}
				TextureImporterSettings tis = new TextureImporterSettings();
				texImporter.ReadTextureSettings(tis);//把ti中的值赋给tis
				//修改部分设置
				tis.maxTextureSize = maxSize;
				tis.readable = true;
				texImporter.SetTextureSettings(tis);//把tis的值赋给ti
				Debug.Log(texImporter.assetPath);
				//保存设置到disk
				AssetDatabase.WriteImportSettingsIfDirty(texImporter.assetPath);
				//更新资源
				AssetDatabase.ImportAsset(texImporter.assetPath, ImportAssetOptions.ForceUpdate);

			} else {
				Debug.Log (path+":找不到在该文件");
			}
		}
	}

}
