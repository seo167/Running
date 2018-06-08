using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WJX{
	//主要用来对对象进行初始化
	public class AssetIniteEdit : MonoBehaviour {
		static AssetIniteEdit _AssetIniteEdit;

		public static AssetIniteEdit Instace{
			get{ 
				if(_AssetIniteEdit==null){
					GameObject obj = new GameObject ();
					obj.name="[AssetIniteEdit]";

					_AssetIniteEdit=obj.AddComponent<AssetIniteEdit> ();
				}
				return _AssetIniteEdit;
			}
		}

		public UnityEvent _Action;

		[SerializeField]List<AssetInite> AssetIniteList;

		public int AssetIniteListCount{
			get{
				if(AssetIniteList==null){
					return 0;
				}
				return AssetIniteList.Count;
			}
		}

		void Awake(){
			_AssetIniteEdit = this;
		}

		public void AddAssetInite(AssetInite temp){

			if(AssetIniteList==null){
				AssetIniteList = new List<AssetInite> ();
			}


			if (AssetIniteList.Count > 0) {
				if (AssetIniteList.Contains (temp)) {
					return;
				}
			}
			AssetIniteList.Add (temp);

		}

		public void IniteTheObj(){
			foreach(var t in AssetIniteList){
				t.Inite ();
				ResClac.MinUsResNum ();
			}
			ResClac.SetZeroFResNum ();

			if(_Action!=null){
				_Action.Invoke ();
			}

		}

	}
}


