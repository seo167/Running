using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WJX
{
    //BGM随机播放
    public class BGMRandomPlay : SoundEffect
    {
        AudioPlane mAudioPlane;

        float offset=0.0f;

      

        public BGMRandomPlay(AudioSource source,AudioPlane _AudioPlane) : base(source) {
            mAudioPlane = _AudioPlane;
        }

        public override void Effect()
        {

            if (_Source.clip!=null&&offset >= _Source.clip.length) {
                offset = 0;
                int index = Random.Range(0,mAudioPlane.GetClipList.Count);
                _Source.clip = mAudioPlane.GetClipList[index];
                _Source.Play();
            }

            offset += Time.deltaTime;

        }

    }
}
