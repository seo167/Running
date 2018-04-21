using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public static class SoundEffectManager{
        public static void SetAudioEffect(AudioSource _source,AudioEffect effect) {
			switch(effect){
			case AudioEffect.ShadeBig:
				//AudioSystem.Instace.AddList (new AudioShadeBig(_source));
				break;
			case AudioEffect.ShadeSmall:
				//AudioSystem.Instace.AddList (new AudioShadeSmall(_source));
				break;
			default:
				//AudioSystem.Instace.AddList(new SoundEffect(_source));
				break;
			}
        }
    }
}


