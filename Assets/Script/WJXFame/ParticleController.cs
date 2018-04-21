using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ParticleController : MonoBehaviour {

	[SerializeField]GameObject[] Particle;

	Dictionary<string,GameObject> ParticleDictionary;

	Queue<ParticleSystem> ParticleQueue;


	ParticleSystem _ParticleSystem;

	private static ParticleController _ParticleController;

	public static ParticleController Instace{
		get{ 
			if(_ParticleController==null){
				_ParticleController = new ParticleController ();
			}
			return _ParticleController;
		}
	}

	private ParticleController(){
		ParticleQueue = new Queue<ParticleSystem> ();
	}

	public int Schedule=0;

	//播放PList粒子
	public void ParticlePlay(string _key,Vector3 _pos){
		GameObject _obj=Resources.Load<GameObject>(_key);
		_obj= GameObject.Instantiate<GameObject>(_obj);
		_obj.transform.position = _pos;

		if(_obj.GetComponent<ParticleSystem>()!=null){
			_obj.GetComponent<ParticleSystem> ().Play ();

			ParticleQueue.Enqueue (_obj.GetComponent<ParticleSystem>());
		}
	}

	public void Logic(){

		if(ParticleQueue.Count==0){
			return;
		}

		_ParticleSystem = ParticleQueue.Peek ();
		if(_ParticleSystem!=null&&!_ParticleSystem.isPlaying){
			DestroyObject (ParticleQueue.Dequeue().gameObject);
		}

	}

	public ParticleSystem GetParticle(){
		if(ParticleQueue.Count==0){
			return null;
		}
		return ParticleQueue.Peek();
	}

	public void ClearParticle(){
		Schedule=0;
		Destroy (ParticleController.Instace);
	}

}
