using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;
using DG.Tweening;
using UnityEngine.UI;
public class MainTitle : UIPlane {

    RectTransform mRectTransform;

    protected override void Awake(){
        mRectTransform = GetComponent<RectTransform>();
        UIManager.Instace.RegisterUIView(UIType.MAINTITLE,this);
    }

    public override void Begin(){
        Sequence temp = DOTween.Sequence();
        AudioSystem.Instace.SenEffectdMsg(GameConfig.AudioPath + "/Se_UI_Slide", AudioState.AudioPlay);
        temp.Append(mRectTransform.DOAnchorPosY(-155.0f, 0.5f).SetEase(Ease.OutBack));
        temp.AppendCallback(()=> {
            Sequence MySeque = DOTween.Sequence();

            MySeque.Append(transform.DOBlendableScaleBy(new Vector2(0.1f,0.2f),1.5f))
            .Insert(1.0f,transform.DOBlendableScaleBy(new Vector2(-0.1f,-0.2f),1.5f)).SetLoops(-1,LoopType.Yoyo);

            UIManager.Instace.ShowUI(UIType.BUTTONARRAY);
        });
    }
}
