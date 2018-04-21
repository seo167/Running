using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX{
	public class SystemBase<T> : MonoBehaviour where T:MonoBehaviour{
		private T _MySystem;

		public T GetMySystem{
			get{ 

				if(_MySystem==null){
					_MySystem = this as T;
				}

				return _MySystem;
			}
		}
	}
}


