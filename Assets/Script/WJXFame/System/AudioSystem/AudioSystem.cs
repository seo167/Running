using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    [System.Serializable]
    public class AudioSystem{
		Dictionary<SoundType,SoundEffect> AudioEffectDictionary;

        Dictionary<string, AudioSource> AudioSourceDictionary;

		AudioSource BGMusic;

        static AudioSystem audioSystem;

        static public AudioSystem Instace {
            get {
				if(audioSystem==null){
					audioSystem = new AudioSystem ();
				}
                return audioSystem;
            }
        }

        private AudioSystem() {
			AudioEffectDictionary = new Dictionary<SoundType,SoundEffect> ();
            AudioSourceDictionary = new Dictionary<string, AudioSource>();
			AudioEffectDictionary.Add (SoundType.AUDIOSHADEBIG,new AudioShadeBig());
			AudioEffectDictionary.Add (SoundType.AUDIOSHADESMALL,new AudioShadeSmall());
		}

        //音效处理
        public void SoundEffectDispose(SoundType _SoundType,string key) {
            
        }

		/// <summary>
		///播放音效,只播放一次
		/// </summary>
		/// <param name="AudioName">声音名字</param>
		public void PlaySoundEffect(string AudioName, float volume = 1.0f, bool audioDelete=true,float delay=0.0f) {
            AudioSource _AudioSource=null;
            if (AudioSourceDictionary.ContainsKey(AudioName)) {
                return;
            }

            CreateSource(ref _AudioSource, volume,AudioName, audioDelete,delay);
        }

        //添加音效
        void CreateSource(ref AudioSource _AudioSource, float volume,string AudioName,bool audioDelete, float delay) {
            AudioClip _clip = Resources.Load<AudioClip>(AudioName);
            if (_clip != null)
            {
                GameObject _obj = new GameObject();
                _AudioSource = _obj.AddComponent<AudioSource>();

                if (audioDelete){
                    _AudioSource.gameObject.AddComponent<Audio>();
                }else {
                    AudioSourceDictionary.Add(AudioName,_AudioSource);
                }
                _AudioSource.volume = volume;
                _AudioSource.name = AudioName;
                _AudioSource.clip = _clip;
                _AudioSource.PlayDelayed(delay);
                _AudioSource.Play();
            }
        }


		public void Clear(){
            AudioSourceDictionary.Clear();
            AudioEffectDictionary.Clear();
        }

		public void PlayBgm(string ClipName,float volume=0.8f){
            if (BGMusic != null){
                BGMusic.volume = volume;
            }else {
                AudioClip _clip = Resources.Load<AudioClip>(ClipName);
                GameObject _obj = new GameObject();
                BGMusic = _obj.AddComponent<AudioSource>();
                BGMusic.clip = _clip;
                BGMusic.loop = true;
                BGMusic.name = "[BGMusic]";
                GameObject.DontDestroyOnLoad(_obj);
            }
            BGMusic.Play();
        }
    }
}


