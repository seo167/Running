using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WJX{
	public class Audio : MonoBehaviour {

		AudioSource mAudioSource;

		string MyAudioName;

        public void Inite(AudioSource _AudioSource) {
            mAudioSource = _AudioSource;
            StartCoroutine("RemoveMusic");
        }

        IEnumerator RemoveMusic() {
            yield return new WaitForSeconds(mAudioSource.clip.length);
            Destroy(mAudioSource.gameObject);
        }

	}
}


