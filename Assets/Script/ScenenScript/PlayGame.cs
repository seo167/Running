using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class PlayGame : MonoBehaviour {

    public void OnClick() {
        UIManager.Instace.UILogic(UIType.CAMERA);
    }
}
