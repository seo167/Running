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

    public PlayerController(Player _player) : base() {
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

    protected override void Awake(){
        Player temp = GetComponent<Player>();
        _Animation = GetComponent<Animation>();
        UIManager.Instace.RegisterController(UIType.PLAYER,new PlayerController(temp));
       
    }

    public override void OnEnter(UnityAction _Action = null){

        _Animation.Play("ready01");
        UIManager.Instace.UILogic(UIType.CAMERA);
    }

    public override void Begin(UnityAction _Action = null)
    {
        StartCoroutine(Move());
    }

    public override void Pause(UnityAction _Action = null)
    {
        //UI视图暂停逻辑
    }

    public override void Logic(UnityAction _Action = null){
       
    }

    public override void OnExit(UnityAction _Action = null)
    {
        //UI视图隐藏逻辑
    }

    IEnumerator Move() {
        _Animation.Play("run");
        while (true) {
            transform.Translate(Vector3.forward*5*Time.deltaTime);
            yield return null;
        }
    }

}
