using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : GameProp{
    protected override void Login(object obj) {
        ((Player)obj).isMuilty = true;
        DelayCoroutine(5.0f,()=> {
            ((Player)obj).isMuilty = false;
        });
    }
}
