using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class Magnet : GameProp{
    protected override void Login(object obj){
        Player p = ((Player)obj);
        p.isMagnet = true;
        DelayCoroutine(5.0f, () => {
            p.isMagnet = false;
        });
    }
}
