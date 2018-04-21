using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class Jump : PlayerState
{

    #region 重力跳跃速度
        float JumpSpeed = 5.0f;
        float GraveJumpSpeed = 0.0f;
    #endregion

    public override void Excute(CharacterController _Player){
        if (GraveJumpSpeed < 2.0f){
            GraveJumpSpeed = JumpSpeed / Gravity;
            JumpSpeed += 100.0f;
        }
        float y = _Player.transform.position.y + (GraveJumpSpeed * Time.deltaTime);
        if (_Player.transform.position.y <2.0f){
            _Player.transform.position = new Vector3(_Player.transform.position.x, y, _Player.transform.position.z);
        }
        else{
            JumpSpeed = 5.0f;
            GraveJumpSpeed = 0.0f;
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).GetPlayerMsg = PlayerMsg.FALL;
            PlayerStateManager.Instace.SetFunc();
        }
    }
}
