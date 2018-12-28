using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class CameraMsg : MonoBehaviourSimply {
    [SerializeField] Transform Player;
    Vector3 offset;
    private void Awake(){
        offset = Player.position - transform.position;
    }

    private void Update(){
        transform.position = Player.position-offset;
    }

    protected override void OnBeforeDestroy(){
        
    }

}
