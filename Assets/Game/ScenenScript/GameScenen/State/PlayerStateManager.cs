using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;
using UnityEngine.Events;

public delegate void STATE(CharacterController mCharacterController);

public class PlayerStateManager{
    private static PlayerStateManager mPlayerStateManager;

    public static PlayerStateManager Instace {
        get {

            if (mPlayerStateManager==null) {
                mPlayerStateManager = new PlayerStateManager();
            }

            return mPlayerStateManager;
        }
    }

    STATE mAction;

    Dictionary<PlayerMsg, PlayerState> mPlayerStateDictionary;

    private PlayerStateManager() {
        mPlayerStateDictionary = new Dictionary<PlayerMsg, PlayerState>();
        mPlayerStateDictionary.Add(PlayerMsg.JUMP,new Jump());
        mPlayerStateDictionary.Add(PlayerMsg.LEFTMOVE,new LeftMove());
        mPlayerStateDictionary.Add(PlayerMsg.RIGHTMOVE,new RightMove());
        mPlayerStateDictionary.Add(PlayerMsg.ROOL,new RightMove());
        mPlayerStateDictionary.Add(PlayerMsg.FALL,new Fall());
        mPlayerStateDictionary.Add(PlayerMsg.DEFAULT, new Run());
    }

    public void SetFunc() {
        PlayerMsg msg = UIManager.Instace.GetModelForT<PlayerModel>(UIType.PLAYER).GetPlayerMsg;
        mAction = null;
        if (msg==PlayerMsg.DEFAULT) {
            return;
        }
        mAction += mPlayerStateDictionary[msg].Excute;
    }

    public void Excute(CharacterController mCharacterController) {
        if (mAction != null){
            mAction(mCharacterController);
        }
        mPlayerStateDictionary[PlayerMsg.DEFAULT].Excute(mCharacterController);
    }

}
