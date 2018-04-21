using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class PlayerControl : AIStates {
    Animation mAnimation;
    public PlayerControl(GameObject _play) : base(AIStateID.PLAYERCONTROLID){
        mAnimation = _play.GetComponent<Animation>();
    }

    public override void StateExcue(){
        if (UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).CanClick) {
            KeyBoardClickKey();
        }
    }

    void KeyBoardClickKey() {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) {
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).CanClick = false;
            mAnimation.GetComponent<Animation>().Play("jump");
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).SendMsg(PlayerMsg.JUMP);
        } else if (Input.GetKeyDown(KeyCode.A)) {

            if (UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).StreetIndex >-1)
            {
                UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).StreetIndex--;
                UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).CanClick = false;
                UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).SendMsg(PlayerMsg.LEFTMOVE);
                mAnimation.GetComponent<Animation>().Play("left_jump");
            }

          
        } else if (Input.GetKeyDown(KeyCode.D)) {
            if (UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).StreetIndex<1) {
                UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).StreetIndex++;
                UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).CanClick = false;
                UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).SendMsg(PlayerMsg.RIGHTMOVE);
                mAnimation.GetComponent<Animation>().Play("right_jump");
            }

           
        } else if (Input.GetKeyDown(KeyCode.S)) {
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).CanClick = false;
            UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).SendMsg(PlayerMsg.ROOL);
        }
        PlayerStateManager.Instace.SetFunc();

    }


}
