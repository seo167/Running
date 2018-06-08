using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WJX{
	//新版本将改成时间判断,取消Update
	public class Audio : MonoBehaviour {

		AudioSource _AudioSource;

		string MyAudioName;

		float AudioLength;//音频长度

        void Awkae() {
            _AudioSource = GetComponent<AudioSource>();
            AudioLength = _AudioSource.clip.length;
        }

		IEnumerator Start(){

			yield return new WaitForSeconds (AudioLength+0.5f);

			while(_AudioSource.loop){
				yield return null;
			}

			DestroyObject (this.gameObject);
		}

	}
}


