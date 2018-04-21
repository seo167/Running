using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class Fall : PlayerState{

    #region 重力跳跃速度
    float FallSpeed = 5.0f;
    float GraveFallSpeed = 0.0f;
    #endregion

    public override void Excute(CharacterController _Player) {
        if (GraveFallSpeed <1.0f){
            GraveFallSpeed = FallSpeed / Gravity;
            FallSpeed += 100.0f;
        }

        float y = _Player.transform.position.y - (GraveFallSpeed * Time.deltaTime);
        if (Mathf.Abs(y-0.0f) > 0.1f){
            _Player.transform.position = new Vector3(_Player.transform.position.x, y, _Player.transform.position.z);
        }else{
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).CanClick = true;
            _Player.GetComponent<Animation>().Play("run");
            PlayAnimation = false;
            FallSpeed = 5.0f;
            GraveFallSpeed = 0.0f;
            PlayAnimation = false;
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).GetPlayerMsg = PlayerMsg.DEFAULT;
            PlayerStateManager.Instace.SetFunc();
        }
    }
}
