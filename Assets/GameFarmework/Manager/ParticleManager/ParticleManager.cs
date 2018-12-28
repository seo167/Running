/***************************************************
 * 文件：ParticleManager.cs
 * 作者：Gavin
 * 邮箱：a277152071@163.com
 * 功能：粒子管理器
 * *************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Farmework {
    public class ParticleManager
    {
        Queue<Particle> ParticleQueue = new Queue<Particle>();
        private static ParticleManager _ParticleManager;
        public static ParticleManager Instace
        {
            get
            {
                if (_ParticleManager == null)
                {
                    _ParticleManager = new ParticleManager();
                }
                return _ParticleManager;
            }
        }

        private ParticleManager() { }

        //播放PList粒子
        public void ParticlePlay(string _key, Vector3 _pos, bool isLoop = false, Transform Parent = null)
        {
            ParticleSystem _obj = Resources.Load<ParticleSystem>(_key);
            _obj = GameObject.Instantiate<ParticleSystem>(_obj, Parent);
            if (_obj != null){
                if (Parent == null)
                    _obj.transform.position = _pos;
                else
                    _obj.transform.localPosition = _pos;
                if (isLoop){
                    ParticleQueue.Enqueue(_obj.gameObject.AddComponent<Particle>());
                }
                else{
                    _obj.gameObject.AddComponent<Particle>();
                }
                _obj.Play();
            }
        }

        //播放带有父类的PList粒子
        public void ParticlePlayForParent(string _key, Vector3 _pos, bool isLoop = false, int LayersNum = 1, Transform Parent = null){
            GameObject _obj = Resources.Load<GameObject>(_key);
            _obj = GameObject.Instantiate<GameObject>(_obj, Parent);
            if (_obj != null){
                if (Parent == null)
                    _obj.transform.position = _pos;
                else
                    _obj.transform.localPosition = _pos;
                int childCount = _obj.transform.childCount;
                for (int i = 0; i < childCount; ++i){
                    Transform child = _obj.transform.GetChild(i);
                    Transform LayerChild = child;
                    for (int j = 0; j < LayersNum-1; ++j){
                        ParticleSystem[] p = LayerChild.GetComponentsInChildren<ParticleSystem>();
                        for (int k=0;k<p.Length;++k) {
                            p[k].loop = isLoop;
                            if (isLoop){
                                ParticleQueue.Enqueue(p[k].gameObject.AddComponent<Particle>());
                            }
                        }
                       
                        LayerChild = LayerChild.GetChild(j);
                    }

                }
            }
        }

        public Particle GetParticle() {
            if (ParticleQueue.Count ==0)
                return null;
            return ParticleQueue.Dequeue();
        }

        public void SetParticle(Particle p) {
            ParticleQueue.Enqueue(p);
        }

    }
}

