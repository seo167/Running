using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace WJX{
	public class ParticleController{
		List<ParticleSystem> ParticleList;

		private static ParticleController _ParticleController;

		public static ParticleController Instace{
			get{ 
				if(_ParticleController==null){
					_ParticleController = new ParticleController ();
				}
				return _ParticleController;
			}
		}

		/// <summary>
		/// 粒子总数
		/// </summary>
		/// <value>The particle count.</value>
		public int ParticleCount{
			get{ 
				return ParticleList.Count;
			}
		}

		private ParticleController(){
			ParticleList = new List<ParticleSystem> ();
		}

		/// <summary>
		/// 粒子播放
		/// </summary>
		/// <returns>The play.</returns>
		/// <param name="_key">Key.</param>
		/// <param name="_pos">Position.</param>
		/// <param name="isLoop">If set to <c>true</c> is loop.</param>
		/// <param name="Parent">Parent.</param>
		/// <param name="delay">Delay.</param>
		/// 会优先在主对象池和次要对象池进行检索，如果两个对象池都没有则创建一个粒子,只会存储loop的粒子
		public ParticleSystem ParticlePlay(string _key,Vector3 _pos,bool isLoop=false,Transform Parent=null,float delay=0.0f){
			ParticleSystem _obj=GetParticle(_key);

			if (_obj == null) {
				CreateParticle (out _obj, _key, _pos, Parent);
			}

			_obj.transform.parent = Parent;
			_obj.transform.position = _pos;

				_obj.loop = isLoop;
				_obj.startDelay = delay;

				if (isLoop) {
					ParticleList.Add (_obj);
				} else {
					//粒子播放完后自动消失
					_obj.gameObject.AddComponent<ParticleLife> ();
				}

				_obj.Play ();

			return _obj;
		}
	
		/// <summary>
		/// 移除粒子
		/// </summary>
		/// <param name="_key">Key.</param>
		public void RemoveParticle(string _key){
			if(ParticleList.Count>0){
				foreach(var t in ParticleList){
					if(t.name.Equals(_key)){
						t.Pause ();
						ParticleList.Remove (t);
						return;
					}
				}
			}					
		}
			
		/// <summary>
		/// 获取粒子
		/// </summary>
		/// <returns>The particle.</returns>
		/// <param name="_key">Key.</param>
		public ParticleSystem GetParticle(string _key){
			//从主对象池获取粒子
			return ParticleList.Find(delegate(ParticleSystem _ParticleSystem){
				return (_ParticleSystem.name.Equals(_key))?_ParticleSystem:null;
			});
		}

		/// <summary>
		/// 获取粒子
		/// </summary>
		/// <returns>The particle.</returns>
		/// <param name="_key">Key.</param>
		void CreateParticle(out ParticleSystem _obj,string _key,Vector3 _pos,Transform Parent){
			_obj=Resources.Load<ParticleSystem>(_key);
			_obj= GameObject.Instantiate<ParticleSystem>(_obj);
			_obj.name = _key;
		}

		public void ClearParticle(){
			ParticleList.Clear ();
		}
	}
}