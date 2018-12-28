using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class Particle : MonoBehaviourSimply {
    ParticleSystem _PS;

    public ParticleSystem GetPS {
        get {
            return _PS;
        }
    }

    // Use this for initialization
    void Start () {
        _PS = GetComponent<ParticleSystem>();
        DelayLoopCoroutine((bool isLoop)=> {
            isLoop = _PS.isPlaying;
        },()=> {
            GameObject.Destroy(_PS.gameObject);
        });
    }

    protected override void OnBeforeDestroy(){

    }
}
