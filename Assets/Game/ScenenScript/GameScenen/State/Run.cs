using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : PlayerState{
    #region 重力移动速度
    float Speed = 10.0f;
    float GraveSpeed = 0.0f;
    #endregion

    public override void Excute(CharacterController _Player){
        if (GraveSpeed < 10.0f){
            GraveSpeed = Speed / Gravity;
            Speed += 10.0f;
        }

        Camera.main.transform.Translate(Vector3.forward * GraveSpeed * Time.deltaTime, Space.World);
        _Player.Move(Vector3.forward * Time.deltaTime * GraveSpeed);
    }
}
