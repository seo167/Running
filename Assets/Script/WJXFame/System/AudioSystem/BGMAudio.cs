using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WJX {
    public class BGMAudio{
        GameObject mBGMObj;

        AudioPlane mAudioPlane;//音频池

        AudioFSMState mAudioState;//音频动作

        Dictionary<AudioEffect, SoundEffect> mSoundEffect;

        AudioSource mBGMSource;

        public BGMAudio(string PlanePath){
            IniteAudioPlane(PlanePath);

          

            mBGMObj = new GameObject();
            mBGMObj.name = GameConfig.BGMOBJName;
            mBGMObj.AddComponent<AudioSource>();
            mBGMSource = mBGMObj.GetComponent<AudioSource>();

            IniteAudioEffect();

            GameObject.DontDestroyOnLoad(mBGMObj);
        }

        void IniteAudioPlane(string PlanePath) {
            GameObject obj = Resources.Load(PlanePath) as GameObject;
            mAudioPlane = GameObject.Instantiate(obj).GetComponent<AudioPlane>();
            mAudioState = new AudioFSMState();
        }

        void IniteAudioEffect() {
            mSoundEffect = new Dictionary<AudioEffect, SoundEffect>();

            mSoundEffect.Add(AudioEffect.ShadeBig,new AudioShadeBig(mBGMSource));
            mSoundEffect.Add(AudioEffect.ShadeSmall, new AudioShadeSmall(mBGMSource));
            mSoundEffect.Add(AudioEffect.RamdonPlay, new BGMRandomPlay(mBGMSource, mAudioPlane));
        }

        public void PlayMusic(string AudioName, AudioState State){
            mBGMSource.clip = mAudioPlane.GetClipForDictionary(AudioName);

            mAudioState.AudioExcute(mBGMSource, State);
            
        }

        public void UseAudioEffect(AudioEffect _AudioEffect) {
            if (_AudioEffect!=AudioEffect.Normal) {
                mSoundEffect[_AudioEffect].Effect();
            }
        }

    }
}
