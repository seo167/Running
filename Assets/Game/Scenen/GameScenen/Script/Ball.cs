using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class Ball : MonoBehaviourSimply {

    bool isShow = false;

    Vector3 defaultPos;
    Transform defaultParent;
    Goal g;
    Transform _Player;
    int direction = 0;//-1为左，0为中间，1为右

    public int Direction {
        get {
            return direction;
        }
    }

    private void Awake(){
        defaultPos = transform.localPosition;
        defaultParent = transform.parent;
        RegisterMsg("Ball", Logic);
        RegisterMsg("BallSetNum", SetNum);
        Hide();
    }

    private void Start(){
        g = GetGameObject("Item_ShootGoal").GetComponent<Goal>();
        _Player = GetGameObject("Player").transform.Find("ParticleParent");
    }

    private void OnEnable(){
        transform.SetParent(null);
    }

    private void FixedUpdate(){
        if (isShow) {
            transform.position = Vector3.Lerp(transform.position, g.transform.position, Time.deltaTime*2.0f);
        }
    }

    void SetNum(object _obj) {
        int num = (int)_obj;
        direction = num;
    }

    void Logic(object _obj) {
        if (!isShow){
            isShow = true;
            Show();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag.Equals("Goalkeeper")) {
            transform.parent = defaultParent;
            SendMsg("Goal", direction);
            ParticleManager.Instace.ParticlePlay("FX_GOAL", new Vector3(-0.04f, 4.05f, 1.22f), false,_Player);
            Hide();
        }
    }

    private void OnDisable(){
        isShow = false;
        transform.localPosition = defaultPos;
    }

    protected override void OnBeforeDestroy(){
        
    }
}
