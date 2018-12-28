using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class BallButton : ButtonClick
{
    protected override void Login(object _obj) {
        GameObject obj=GetGameObject("Player");
       
        SendMsg("Ball",0);
    }
}
