using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace WJX{

	//资源初始化
	public class AssetInite : MonoBehaviour {

		[SerializeField]protected string AssetPathName;

		[SerializeField]protected string AssetBundlePathName;

		public string GetAssetBundlePathName{
			get{
				return AssetBundlePathName;
			}
		}

		[SerializeField]UnityEvent _Action;

		public UnityEvent Action{
			get{
				return _Action;
			}
		}

		enum AssetType{
			ASSETSTREAMING,
			ASSETBUNDLE
		}

		[SerializeField]AssetType _AssetType;

		public void Inite(){
			if (_AssetType == AssetType.ASSETBUNDLE) {
				SetObj ();
			} else {
				ResourseAssetManager.Instace.LoadStreamingAsset (AssetPathName,SetPicture);
			}

			if(_Action!=null){
				_Action.Invoke ();
			}

		}

		public void SetAsset(string mName){
			AssetPathName = mName;
			_AssetType = AssetType.ASSETSTREAMING;
		}

		public void SetAssetBundleName(string mName){
			AssetBundlePathName = mName;
			_AssetType = AssetType.ASSETBUNDLE;
		}

		protected virtual void SetPicture(Texture _picture){
			if(_picture!=null){
				if(GetComponent<Image>()!=null){
					GetComponent<Image> ().sprite = Sprite.Create ((Texture2D)_picture,new Rect(0,0,_picture.width,_picture.height),new Vector2(0.5f,0.5f));
					Destroy (GetComponent<AssetInite>());
					return;
				}

				if(GetComponent<SpriteRenderer>()!=null){
					GetComponent<SpriteRenderer> ().sprite = Sprite.Create ((Texture2D)_picture,new Rect(0,0,_picture.width,_picture.height),new Vector2(0.5f,0.5f));
					Destroy (GetComponent<AssetInite>());
					return;
				}
			}
		}

		protected virtual void SetObj(){
			Texture2D _tex = (Texture2D)ResourseAssetManager.Instace.GetDictionary (AssetBundlePathName.ToLower());
			if(_tex==null){
				Debug.Log ("空的,"+AssetBundlePathName.ToLower());

				return;
			}
			if(this.GetComponent<Image>()!=null){
				GetComponent<Image> ().sprite = Sprite.Create (_tex,new Rect(0,0,_tex.width,_tex.height),new Vector2(0.5f,0.5f));
			}else if(GetComponent<SpriteRenderer>()!=null){
				GetComponent<SpriteRenderer>().sprite=Sprite.Create (_tex,new Rect(0,0,_tex.width,_tex.height),new Vector2(0.5f,0.5f));
			}


		}
	}
}


