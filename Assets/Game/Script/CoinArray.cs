using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class CoinArray : MonoBehaviourSimply {

    List<Coin> CoinList = new List<Coin>();

    protected override void OnBeforeDestroy()
    {
        
    }

    // Use this for initialization
    void Awake () {
        for (int i=0;i<transform.childCount;++i) {
            CoinList.Add(transform.GetChild(i).GetComponent<Coin>());
        }
	}

    public void ShowCoin() {
        for (int i = 0; i < transform.childCount; ++i){
            CoinList[i].Show();
        }
    }

}
