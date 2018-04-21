using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class HomeScenen : ScenenState {
    //场景初始化
    public override void ScenenStart(){
        Application.runInBackground = true;
        AudioSystem.Instace.BGMAudioInite("AudioPlane/[BgmPlane]");

       AudioSystem.Instace.SendBGMMsg("Bgm_JieMian", AudioState.AudioPlay);

        for (int i=0;i<5;++i) {
            AudioSystem.Instace.SendBGMMsg("Bgm_JieMian", AudioState.LessVolume);
        }

        UIManager.Instace.ShowUI(UIType.MAINTITLE);
       
    }

    //场景逻辑
    public override void ScenenLogic(){
       AudioSystem.Instace.GetBGMAudioBase.UseAudioEffect(AudioEffect.RamdonPlay);
    }

    //场景结束
    public override void ScenenEnd(){

    }
}
