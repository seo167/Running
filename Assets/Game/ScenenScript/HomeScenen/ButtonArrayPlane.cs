using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;
using DG.Tweening;

public class ButtonArrayPlane : UIPlane {

    protected override void Awake() {
        UIManager.Instace.RegisterUIView(UIType.BUTTONARRAY,this);
    }

    public override void Begin(){
        AudioSystem.Instace.SenEffectdMsg(GameConfig.AudioPath + "/Se_UI_Slide", AudioState.AudioPlay);
        GetComponent<RectTransform>().DOAnchorPosY(100.0f,0.5f).SetEase(Ease.OutBack);
    }

}
