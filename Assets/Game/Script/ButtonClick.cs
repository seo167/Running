using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
using UnityEngine.UI;
using System;

public abstract class ButtonClick : MonoBehaviourSimply {
    [SerializeField]protected string name;
    static public string PrevBtName = "";

    // Use this for initialization
    void Awake () {
       
        GetComponent<Button>().onClick.AddListener(OnClick);
        RegisterMsg(name,Login);
	}

    public void OnClick() {
        SendMsg(name, null);
    }

    protected override void OnBeforeDestroy(){
        UnRegister(name, Login);
    }

    protected abstract void Login(object _obj);
}

