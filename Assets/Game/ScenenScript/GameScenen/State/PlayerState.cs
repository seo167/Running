using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState {

    #region 重力
    protected float mass = 5.0f;//质量
    protected float GravityCoefficient = 10.0f;//重力系数
    protected float Gravity=30.0f;

    #endregion

    protected bool PlayAnimation = false;

    public abstract void Excute(CharacterController _Player);
}
