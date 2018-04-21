using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    [System.Serializable]
    public class AudioSystem{

        BGMAudio mBGMAudio;

        public BGMAudio GetBGMAudioBase {
            get {
                return mBGMAudio;
            }
        }

        static AudioSystem audioSystem;

        static public AudioSystem Instace {
            get {

				if(audioSystem==null){
					audioSystem = new AudioSystem ();
				}
                return audioSystem;
            }
        }

        private AudioSystem() {}

        //要手动设置
        public void BGMAudioInite(string RepeateAudioPath)
        {
            if (mBGMAudio == null)
            {
                mBGMAudio = new BGMAudio(RepeateAudioPath);
            }
        }

        public void SenEffectdMsg(string AudioPath,AudioState state) {
            AudioClip _clip = Resources.Load<AudioClip>(AudioPath);
            GameObject obj = new GameObject();
            obj.AddComponent<AudioSource>().clip = _clip;
            obj.AddComponent<Audio>().Inite(obj.GetComponent<AudioSource>());
            obj.GetComponent<AudioSource>().Play();

        }

        public void SendBGMMsg(string AudioName, AudioState state) {
            mBGMAudio.PlayMusic(AudioName,state);
        }

        public void SetBGMsgEffect(AudioEffect _AudioEffect) {

        }

    }
}


