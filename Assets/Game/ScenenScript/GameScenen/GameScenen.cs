using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class GameScenen : ScenenState
{


    //场景初始化
    public override void ScenenStart(){
        PoolManager.Instace.RegisterPool(PoolType.PATTERN, new PatternPool());
        PoolManager.Instace.RegisterPool(PoolType.ITEM,new ItemPool());
        PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).NowPattern = PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).GetObj(0);
        PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).NextPattern = PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).GetObj(2);
        PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).NowPattern.transform.localPosition = Vector3.zero;
        PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).NextPattern.transform.localPosition = new Vector3(0, 0, 160.0f);
        PoolManager.Instace.GetPool<ItemPool>(PoolType.ITEM).SetItem();

    }

    //场景逻辑
    public override void ScenenLogic()
    {
        // AudioSystem.Instace.GetBGMAudioBase.UseAudioEffect(AudioEffect.RamdonPlay);
        UIManager.Instace.UILogic(UIType.PLAYER);
    }

    //场景结束
    public override void ScenenEnd()
    {

    }
}
