using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX{
	//对象池系统
	public class PoolSystem{
		List<GameObject> _ObjPool;

		private static PoolSystem _PoolSystem;

		public static PoolSystem Instace{
			get{ 
				if(_PoolSystem==null){
					_PoolSystem = new PoolSystem ();
				}
				return _PoolSystem;
			}
		}

		int _NumCount=0;
	
		private PoolSystem(){
			_ObjPool = new List<GameObject> ();
		}

		public void PushInList(GameObject _Obj){
			//如果小于100则加入对象池，否则移除第一个元素
			if (_NumCount < 100) {
				++_NumCount;
			} else {
				GameObject temp=_ObjPool[0];
				GameObject.Destroy (temp);
				_ObjPool.RemoveAt (0);
			}

			_ObjPool.Add (_Obj);
		}

		//从list获取元素
		public GameObject GetObjInList(int index){
			int temp = 0;
			if(index<100){
				temp = index;
			}

			return _ObjPool[temp];

		}

		public int GetObjLength{
			get{ 
				return _ObjPool.Count;
			}

		}

		public void PushArrayInList(GameObject[] _objArray){
			for(int i=0;i<_objArray.Length;++i){
				_ObjPool.Add (_objArray[i]);
				++_NumCount;
			}
		}

		//获取随机对象
		public GameObject GetRangeObj(){
			int num = Random.Range (0,_ObjPool.Count-1);
			if(num<0){
				return null;
			}
			return _ObjPool[num];
		}

		public void Clear(){
			_NumCount = 0;

			for(int i=0;i<_ObjPool.Count;++i){
				GameObject.Destroy (_ObjPool [i]);
			}

			_ObjPool.Clear ();
		}

		public void Clear(int i){
			_ObjPool.RemoveAt (i);
		}

	}
}


