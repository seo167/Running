using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class Player : UIPlane {

    AISystem _AISystem;

    CharacterController mCharacterController;

    protected override void Awake() {
        UIManager.Instace.RegisterUIView(UIType.PLAYER, this);
        UIManager.Instace.RegisterUIModel(UIType.PLAYER, new PlayerModel(this.gameObject));
        mCharacterController = GetComponent<CharacterController>();
        _AISystem = new AISystem();
        _AISystem.RegisterAIstates(AIState.PLAYERCONTROL, new PlayerControl(this.gameObject));

    }

    public override void Enable() {

    }

    public override void Logic(){
        _AISystem.StateExcue(AIState.PLAYERCONTROL);
        PlayerStateManager.Instace.Excute(mCharacterController);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag=="Road") {
            PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).SetPattern();
            PoolManager.Instace.GetPool<ItemPool>(PoolType.ITEM).SetItem();
        }
    }

}
