using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class Player : MonoBehaviourSimply {
    Animation PlayerAnimation;
    float JumpSpeed = 1.5f;
    float RunSpeed = 5;
    float RunSpeedTemp = 5;
    float DefaultMinX=0;
    float DefaultMaxX=0;
    bool isGround = true;
    bool isLMove = false;
    bool isRMove = false;
    bool isDie = false;
    bool isRoll = false;
    public bool isMuilty = false;
    public bool isInvincible = false;
    public bool isMagnet = false;
    int LR = 0;//0代表中间，-1代表左，1代表右
    int HP = 100;
    float SearchCoinRadius = 5.0f;
    int distance = 0;
    int CoinNumber = 0;
    private void Awake(){
        
        PlayerAnimation = GetComponent<Animation>();
        RegisterMsg("Player", ChangeState);
        RegisterObj();
    }

    // Use this for initialization
    void Start () {
        AudioManager.Instace.PlayClip("Audio/UI/Se_UI_Run",true);
        PlayerAnimation.Play("run");
    }
    private void FixedUpdate(){
        if (distance!=0&&distance %500==0) {
            RunSpeed += 1;
            RunSpeedTemp = RunSpeed;
        }
        if (!isDie){
            Jump();
            Roll();
            LeftJump();
            RightJump();
            transform.Translate(Vector3.forward * Time.deltaTime * RunSpeed);
        }
    }

    private void LateUpdate(){
        if (!isDie){
            distance += 1;
            SendMsg("AddDistance", distance);
        }
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)&&isGround){
            isGround = false;
            AudioManager.Instace.StopPlayClip("Audio/UI/Se_UI_Run");
            AudioManager.Instace.PlayClip("Audio/UI/Se_UI_Jump");
            PlayerAnimation.Play("jump");
            PlayerController.Jump(GetComponent<Rigidbody>(), JumpSpeed);
            DelayCoroutine(1.0f, () => {
                if (!isGround){
                    isGround = true;
                    PlayerAnimation.Play("run");
                    AudioManager.Instace.PlayClip("Audio/UI/Se_UI_Run", true);
                }

            });
        }
    }

    void Roll() {
        if (Input.GetKeyDown(KeyCode.S)&&!isRoll)
        {
            isRoll = true;
            PlayerAnimation.Play("roll");
            PlayerController.Roll(GetComponent<Rigidbody>(), JumpSpeed);
            isGround = true;
            DelayCoroutine(0.5f, () => {
                isRoll = false;
                PlayerAnimation.Play("run");
            });
        }
    }

    void LeftJump() {
        if (Input.GetKeyDown(KeyCode.A)&& LR>-1&&!isLMove&& !isRMove&&isGround) {
            isLMove = true;
            PlayerAnimation.Play("left_jump");
            DefaultMinX -= 2;
            --LR;
        }
        if (isLMove) {
            Vector3 temp;
            if (Mathf.Abs(2 * LR-transform.localPosition.x)>0.1f){
                temp = transform.localPosition;
                temp.x -= 0.1f;
                transform.localPosition = temp;
            }else {
                temp = transform.localPosition;
                temp.x = 2 * LR;
                transform.localPosition = temp;
                isLMove = false;
                PlayerAnimation.Play("run");
                SendMsg("BallSetNum",LR);
            }
            
        }
    }

    void RightJump(){
        if (Input.GetKeyDown(KeyCode.D) && LR < 1&&!isLMove&&!isRMove && isGround){
            isRMove = true;
            PlayerAnimation.Play("right_jump");
            ++LR;
            DefaultMaxX += 2;
        }
        if (isRMove){
            Vector3 temp;
            if (Mathf.Abs(2 * LR - transform.localPosition.x) > 0.1f){
                temp = transform.localPosition;
                temp.x += 0.1f;
                transform.localPosition = temp;
            }else{
                temp = transform.localPosition;
                temp.x = 2 * LR;
                transform.localPosition = temp;
                isRMove = false;
                PlayerAnimation.Play("run");
                SendMsg("BallSetNum", LR);
            }

        }
    }

    void ChangeState(object _obj) {

    }

    protected override void OnBeforeDestroy(){
        
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag.Equals("Goalkeeper")) {
            SendMsg("Goal", 2);
            SetHp();
        }
    }

    private void OnTriggerEnter(Collider other){
        string tag = other.gameObject.tag;
        if (tag == "Coin"){
            if (isMuilty){
                SendMsg("AddCoin", 2*(CoinNumber += 2));
            }
            else {
                SendMsg("AddCoin", CoinNumber+=2);
            }
            other.gameObject.SetActive(false);
            ParticleManager.Instace.ParticlePlay("xing",other.transform.position);
            AudioManager.Instace.PlayClip("Audio/UI/Se_UI_JinBi");
        }

        if (!isInvincible) {
            if (tag == "Front")
            {
                ClissionBox(other);
            }

            if (tag == "Left")
            {
                AudioManager.Instace.PlayClip("Audio/UI/Se_UI_Zhuang");
                ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System", transform.position);
                ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System02", transform.position);
                ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System03", transform.position);
                isRMove = false;
                --LR;
                if (HP > 0){
                    SetHp();
                    if (HP <= 0){
                        isDie = true;
                        AudioManager.Instace.StopPlayClip("Audio/UI/Se_UI_Run");
                        DelayCoroutine(0.3f, () => {
                            PlayerAnimation.Play("die");
                            AudioManager.Instace.PlayClip("Audio/UI/Se_UI_End");
                        });
                    }
                    isLMove = true;
                }
            }

            if (tag == "Right"){
                AudioManager.Instace.PlayClip("Audio/UI/Se_UI_Zhuang");
                ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System", transform.position);
                ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System02", transform.position);
                ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System03", transform.position);
                isLMove = false;
                ++LR;
                if (HP > 0){
                    PlayerAnimation.Play("run");
                    SetHp();
                    if (RunSpeed <= 0){
                        isDie = true;
                        AudioManager.Instace.StopPlayClip("Audio/UI/Se_UI_Run");
                        DelayCoroutine(0.3f, () => {
                            PlayerAnimation.Play("die");
                            AudioManager.Instace.PlayClip("Audio/UI/Se_UI_End");
                        });
                    }
                    isRMove = true;
                }
            }
            if (tag == "BigFence" && !isRoll){
                ClissionBox(other);
            }
        }

       
        if (tag== "Multiply") {
            other.gameObject.SetActive(false);
            SendMsg("Multiply",this);
            SendMsg("PropSetTime",0);
        }

        if (tag== "Shield") {
            SendMsg("Shield",this);
            SendMsg("PropSetTime", 2);
        }

        if (tag == "magnet"){
            Debug.Log(other.gameObject.name);
            //SendMsg("Magnet", this);
        }

        if (tag=="StreetBuild") {
            SendMsg("StreetPool",null);
        }

    }

    void ClissionBox(Collider other) {
        isDie = true;
        PlayerAnimation.Play("Collision");
        AudioManager.Instace.StopPlayClip("Audio/UI/Se_UI_Run");
        AudioManager.Instace.PlayClip("Audio/UI/Se_UI_Zhuang");
        DelayCoroutine(0.3f, () => {
            PlayerAnimation.Play("die");
            AudioManager.Instace.PlayClip("Audio/UI/Se_UI_End");
        });
        ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System", other.transform.position);
        ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System02", other.transform.position);
        ParticleManager.Instace.ParticlePlay("ZhuangJi/Particle System03", other.transform.position);
    }

    void SetHp() {
        HP -= 50;
        SendMsg("HpBar", HP);
        RunSpeed = 2;
        DelayCoroutine(3.0f, () => {
            RunSpeed = RunSpeedTemp;
        });
    }

}
