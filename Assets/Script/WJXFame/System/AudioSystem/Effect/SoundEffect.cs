using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    //声效
    public class SoundEffect{
        protected AudioSource _Source;

        protected bool _CanDelete = false;

        public bool CanDelete {
            get {
                return _CanDelete;
            }
        }

		public void SetAudioSource(AudioSource tempSource){
			_Source = tempSource;
			Inite ();
		}

		protected virtual void Inite(){
			//.......
		}

        public virtual void Effect() {
            DeleteSound();
        }

        protected void DeleteSound() {
			if (_Source != null&&!( _Source.isPlaying)&&!(_Source.loop)) {
                _CanDelete = true;
                _Source.clip = null;
                GameObject.Destroy(_Source.gameObject);
            }
        }

    }
}


