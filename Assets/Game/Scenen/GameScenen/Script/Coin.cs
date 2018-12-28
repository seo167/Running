using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class Coin :MonoBehaviourSimply  {

    Vector3 DefaultPos;
    Animation CoinAnimation;
    Player _Player;
    void Awake(){
        DefaultPos = transform.position;
        CoinAnimation = GetComponent<Animation>();
    }

    private void Start()
    {
        _Player= GetGameObject("Player").GetComponent<Player>();
    }

    private void OnEnable()
    {
       // CoinAnimation.Play();
    }

    private void FixedUpdate(){
        if (_Player.isMagnet||transform.position!=DefaultPos) {
            Vector3 PlayerPos = _Player.transform.position;
            float distance = Vector3.Distance(PlayerPos, transform.position);
            if (distance < 5.0f){
                transform.position = Vector3.Lerp(transform.position, PlayerPos, Time.deltaTime * 10.0f);
            }
        }
        
    }

    public void Reset(){
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = DefaultPos;
       
    }

    private void OnDisable() {
        Reset();
    }

    protected override void OnBeforeDestroy(){
        
    }

    

}
