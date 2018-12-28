using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//玩家控制器
public class PlayerController{
    static public void Jump(Rigidbody _rigidbody,float Speed) {
        _rigidbody.velocity += new Vector3(0, 5.0f, 0);
        _rigidbody.AddForce(Vector3.up* Speed, ForceMode.VelocityChange);
    }

    static public void LeftMove(float Speed) {
        //_rigidbody.AddForce(Vector3.left*Speed, ForceMode.VelocityChange);
    }

    static public void Roll(Rigidbody _rigidbody, float Speed) {
        _rigidbody.AddForce(Vector3.up * (-Speed), ForceMode.VelocityChange);
    }

}
