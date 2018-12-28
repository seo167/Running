using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public abstract class GameProp : MonoBehaviourSimply {
    [SerializeField]string PropertyName;

    private void Awake(){
        RegisterMsg(PropertyName, Login);   
    }

    protected abstract void Login(object obj);


    protected override void OnBeforeDestroy()
    {
        
    }
}
