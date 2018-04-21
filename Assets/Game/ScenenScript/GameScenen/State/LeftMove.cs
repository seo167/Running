using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;
public class LeftMove : PlayerState{
    #region 重力右移动
    float RightMoveSpeed = 10.0f;
    float GraveRightMoveSpeed = 0.0f;
    #endregion

    float DscMove = -99;

    public override void Excute(CharacterController _Player)
    {

        if (DscMove == -99)
        {
            DscMove = _Player.transform.position.x - 1.5f;
        }

        if (GraveRightMoveSpeed < 10.0f)
        {
            GraveRightMoveSpeed = RightMoveSpeed / Gravity;
            RightMoveSpeed +=5.0f;
        }

        float x = _Player.transform.position.x - (GraveRightMoveSpeed * Time.deltaTime);
        if (_Player.transform.position.x> DscMove)
        {
            _Player.transform.position = new Vector3(x, _Player.transform.position.y, _Player.transform.position.z);
        }
        else
        {
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).CanClick = true;
            _Player.GetComponent<Animation>().Play("run");
            _Player.transform.position = new Vector3(DscMove, _Player.transform.position.y, _Player.transform.position.z);
            RightMoveSpeed = 5.0f;
            DscMove = -99;
            GraveRightMoveSpeed = 0.0f;
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).GetPlayerMsg = PlayerMsg.DEFAULT;
            PlayerStateManager.Instace.SetFunc();
        }

    }
}
