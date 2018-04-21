using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public enum PlayerMsg {
    DEFAULT,
    JUMP,
    LEFTMOVE,
    RIGHTMOVE,
    ROOL,
    FALL
}

public class PlayerModel : UIModel {

    Animation mPlayerAnimation;

    CharacterController mCharacterController;

    PlayerMsg mMsg=PlayerMsg.DEFAULT;

    GameObject mPlayer;

    public PlayerMsg GetPlayerMsg {
        get {
            return mMsg;
        }
        set {
            mMsg = value;
        }
    }

    bool mCanClick = true;

    public bool CanClick {
        get {
            return mCanClick;
        }
        set {
            mCanClick = value;
        }
    }

    short mStreetIndex = 0;

    public short StreetIndex {
        get {
            return mStreetIndex;
        }
        set {
            mStreetIndex = value;
        }
    }


    public PlayerModel(GameObject obj){
        mPlayer = obj;
        mPlayerAnimation = mPlayer.GetComponent<Animation>();
        mCharacterController = mPlayer.GetComponent<CharacterController>();
    }

    public void SendMsg(PlayerMsg msg) {
        mMsg = msg;
    }
}
