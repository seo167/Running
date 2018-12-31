using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour {
    [SerializeField] CoinArray[] _CoinArray;
    [SerializeField] Transform Item;
    public void Reset()
    {
        for (int i=0;i< Item.childCount;++i) {
            Item.GetChild(0).gameObject.SetActive(true);
        }

        for (int i=0;i<_CoinArray.Length;++i) {
            _CoinArray[i].ShowCoin();
        }

    }
}
