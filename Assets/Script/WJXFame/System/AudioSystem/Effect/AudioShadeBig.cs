using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class AudioShadeBig : SoundEffect{

        //在这个时间内把声音调整为1
        float PlayInterval = 0.5f;

        //当前时间
        float AtPresentTime = 0.0f;

        float AddForMinutes = 0.0f;//每次提升的数

        float AddTheTime = 0.0f;//在这个时间进行音量调整

        public AudioShadeBig(AudioSource source) : base(source) {
            AddForMinutes = (1.0f / PlayInterval) / 10.0f;
            AddTheTime = PlayInterval * AddForMinutes;
        }

        public override void Effect() {
            //获取当前时间
            AtPresentTime = Time.deltaTime;

            if (_Source.volume < 1.0f)
            {
                if ((Time.deltaTime - AtPresentTime) >= AddTheTime){
                    _Source.volume += AddForMinutes;
                }
            }
            else {
                _CanDelete = true;
                DeleteSound();
            }
        }
    }
}

