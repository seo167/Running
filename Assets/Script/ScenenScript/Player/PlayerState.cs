using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public enum FSMID{
    READY,
    JUMP,
    RUN,
    ROOL,
    LEFTJUMP,
    RIGHTJUMP
}

public class PlayerFSM: FSM{
    protected string AnimationName ;
    protected Player player;
    public PlayerFSM(string _AnimationName,short id, GameObject obj):base(id,obj){
        AnimationName = _AnimationName;
        player = obj.GetComponent<Player>();
    }

    public void PlayAnimation(){
        player.GetAnimation.Play(AnimationName);
    }

    public override void FsmLogic(){}
}

public class Jump : PlayerFSM
{
   
    public Jump(GameObject obj) : base("jump",(short)FSMID.JUMP,obj)
    {
        
    }

    public override void FsmLogic(){
       
    }
}
public class LeftJump : PlayerFSM {

    public LeftJump(GameObject obj):base("left_jump",(short)FSMID.LEFTJUMP,obj) {

    }

    public override void FsmLogic(){

    }
}

public class RightJump : PlayerFSM {

    public RightJump(GameObject obj):base("right_jump",(short)FSMID.RIGHTJUMP,obj) {
    }

    public override void FsmLogic(){

    }
}

public class Roll : PlayerFSM {

    public Roll(GameObject obj):base("rool",(short)FSMID.ROOL,obj) {
        player = obj.GetComponent<Player>();
    }

    public override void FsmLogic(){

    }
}


public class Run : PlayerFSM{

    List<PlayerFSM> _FSMList;

    public int ListCount{
        get{
            return _FSMList.Count;
        }
    }

    public Run(GameObject obj) : base("run",(short)FSMID.RUN, obj) { 
        _FSMList = new List<PlayerFSM>();
    }

    public void AddFSM(PlayerFSM _fsm){
        _FSMList.Add(_fsm);
    }

    public override void FsmLogic(){

    }

    public short GetListID(int num){
        return (short)_FSMList[num].GetID;
    }

}

public class Ready : PlayerFSM
{
    public Ready(GameObject obj) : base("ready01",(short)FSMID.READY,obj){

    }

    public override void FsmLogic(){
        player.GetAnimation.Play(AnimationName);
    }
}

//主要状态注册
public class PlayerState{
    Run run;
    Jump j;
    LeftJump lj;
    RightJump rj;
    Roll r;
    Ready ready;

    PlayerFSM _NowFsm;

    public PlayerFSM NowFsm{
        get{
            return _NowFsm;
        }
    }

    public PlayerState(GameObject obj)
    {
        run = new Run(obj);
        j = new Jump(obj);
        lj = new LeftJump(obj);
        rj = new RightJump(obj);
        r = new Roll(obj);
        ready = new Ready(obj);

        InitState();

    }

    void InitState(){

        ready.SetNext(run);

        j.SetNext(r);
        run.AddFSM(j);

        lj.SetNext(r);
        run.AddFSM(lj);

        rj.SetNext(r);
        run.AddFSM(rj);

        r.SetNext(j);
        run.AddFSM(r);
    }

    public void SetState(FSMID id){

        if((_NowFsm != null)&&(!CheckID(id))){
            return;
        }

        switch(id){
            case FSMID.READY:
                _NowFsm = ready;
                break;
            case FSMID.JUMP:
                _NowFsm = j;
                break;
            case FSMID.LEFTJUMP:
                _NowFsm = lj;
                break;
            case FSMID.RIGHTJUMP:
                _NowFsm = rj;
                break;
            case FSMID.ROOL:
                _NowFsm = r;
                break;
            case FSMID.RUN:
                _NowFsm = run;
                break;
        }
        _NowFsm.PlayAnimation();
    }

    bool CheckID(FSMID id){

        if (_NowFsm.GetID == (short)FSMID.RUN){
            for (int i = 0; i < run.ListCount; ++i)
            {
                if (run.GetListID(i) == (short)id)
                {
                    return true;
                }
            }
           
        }else{
            if(_NowFsm.Next.GetID==(short)id){
                return true;
            }
        }
        return false;
    }

    public void Logic(){
        if(_NowFsm!=null)
            _NowFsm.FsmLogic();
    }

}