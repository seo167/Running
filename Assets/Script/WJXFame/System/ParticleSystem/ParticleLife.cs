using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX{
	public class ParticleLife : MonoBehaviour {

		ParticleSystem _MyParticleSystem;

		// Use this for initialization
		IEnumerator Start () {
			_MyParticleSystem = GetComponent<ParticleSystem> ();

			while(_MyParticleSystem.isPlaying){
				yield return null;
			}

			Destroy (_MyParticleSystem.gameObject);


		}
	}
}
