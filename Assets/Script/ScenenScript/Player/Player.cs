using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;
using UnityEngine.Events;

public class PlayerController : UIController {

    Player _PlayerPlane;

    PlayerModel _PlayerModel;

    public PlayerModel GetPlayerModel {
        get {
            return _PlayerModel;
        }
    }

    public Player GetPlayer{
        get{
            return _PlayerPlane;
        }
    }

    public PlayerController(Player _player) : base()
    {
        _PlayerPlane = _player;
        _PlayerModel = new PlayerModel();
        _PlayerPlane.OnEnter();
    }

    public override void ControllerLogic() {
        _PlayerPlane.Begin();
    }

}

public class PlayerModel : UIModel {
    float speed=5.0f;

    public float Speed {
        get {
            return speed;
        }
        set {
            speed = value;
        }
    }

}

public class Player : UIPlane {

    Animation _Animation;

    //获取动画组件
    public Animation GetAnimation {
        get {
            return _Animation;
        }
    }

    //动画名称
    string[] _AnimationName={
        "ready01",
        "run",
        "die",
        "Dress",
        "easter",
        "flutter",
        "fly",
        "jump",
        "left_flutter",
        "left_jump",
        "ready02",
        "right_flutter",
        "right_jump",
        "rool",
        "Shoot01",
        "Shoot02"
    };

    PlayerState playerState;

    //进行注册
    protected override void Awake(){
        _Animation = GetComponent<Animation>();
        playerState = new PlayerState(this.gameObject);
        UIManager.Instace.RegisterController(UIType.PLAYER,new PlayerController(GetComponent<Player>()));
    }

    //开始游戏
    public override void OnEnter(UnityAction _Action = null){
        playerState.SetState(FSMID.READY);
    }

    public override void Begin(UnityAction _Action = null){
        StartCoroutine(Move());
    }

    public override void Pause(UnityAction _Action = null){
       
    }

    public override void Logic(UnityAction _Action = null){
       
    }

    public override void OnExit(UnityAction _Action = null){
        
    }

    IEnumerator Move() {
        playerState.SetState(FSMID.RUN);
        while (true) {
            transform.Translate(Vector3.forward*5*Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.A)){
                playerState.SetState(FSMID.LEFTJUMP);
            }else if(Input.GetKeyDown(KeyCode.D)){
                playerState.SetState(FSMID.RIGHTJUMP);
            }
            playerState.Logic();
            yield return null;
        }
    }

}
