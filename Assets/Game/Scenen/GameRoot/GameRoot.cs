using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
using UnityEngine.UI;
public class GameRoot : MonoBehaviourSimply {
    [SerializeField] Image LOGO;

    // Use this for initialization
    void Start () {
        GameManager.Instance.RegisterAction(HideLoGo, GameManagerActionType.FixedUpdateAction);
    }

    void HideLoGo() {
        Color color = LOGO.color;
        if (color.a > 0){
            color.a -= 0.01f;
            LOGO.color = color;
        }else {
            LevelManager.Instance.AsyncLoadScenen(0,null);
            GameManager.Instance.UnRegisterAction(HideLoGo,GameManagerActionType.FixedUpdateAction);
        }
    }


    protected override void OnBeforeDestroy()
    {
        
    }
}
