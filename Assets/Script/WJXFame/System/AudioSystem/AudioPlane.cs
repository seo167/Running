using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class AudioPlane : MonoBehaviour
    {
        [SerializeField] AudioClip[] _clipArray;

        List<AudioClip> _ClipList;

        public List<AudioClip> GetClipList {
            get {
                return _ClipList;
            }
        }

        public AudioClip GetClipForDictionary(string AudioName) {
            foreach (var t in _ClipList) {
                if (t.name.Equals(AudioName)) {
                    return t;
                }
            }
            return null;
        }

        void Awake() {
            _ClipList = new List<AudioClip>();
            for (int i=0;i<_clipArray.Length;++i) {
                _ClipList.Add(_clipArray[i]);
                _clipArray[i] = null;
            }
        }
    }
}


