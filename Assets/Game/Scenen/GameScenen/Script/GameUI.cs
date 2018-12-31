using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Farmework;
public class GameUI : MonoBehaviourSimply {
    [SerializeField] Text CoinText;
    [SerializeField] Text DistanceText;
    [SerializeField] GameObject hpBar;
    [SerializeField] Sprite MultiplySpirte;//双倍奖励图标
    [SerializeField] Sprite MagnetSprite;//磁铁图标
    [SerializeField] Sprite ShieldSprite;//护盾图标

    [SerializeField] Image[] ImageArray;

    Text HPText;
    Image HP;
    // Use this for initialization
    void Awake () {
        HP = hpBar.transform.Find("Bar").GetComponent<Image>();
        HPText = hpBar.transform.Find("Bar/Text").GetComponent<Text>();
        for (int i=0;i<ImageArray.Length;++i){
            if ((i+1)<ImageArray.Length) {
                Image temp = ImageArray[i];
                ImageArray[i] = ImageArray[i + 1];
                ImageArray[i + 1] = temp;
                ImageArray[i].gameObject.SetActive(false);
            }
        }
        RegisterMsg("AddDistance", AddDistance);
        RegisterMsg("AddCoin",AddCoin);
        RegisterMsg("HpBar",HpBar);
        RegisterMsg("PropSetTime", PropSetTime);
	}

    void AddDistance(object obj) {
        int num = (int)obj;
        DistanceText.text = num.ToString()+" 米";
    }

    void AddCoin(object obj) {
        int str = (int)obj;
        CoinText.text = str.ToString();
    }

    void HpBar(object obj) {
        int hpNum = (int)obj;
        HPText.text = hpNum.ToString();
        float NUM = HP.fillAmount * 100;
        NUM -= 50;
        NUM /=100;
        HP.fillAmount = NUM;
    }

    //道具计时
    void PropSetTime(object obj) {
        for (int i=0;i<ImageArray.Length;++i) {
            if (ImageArray[i].gameObject.active){
                continue;
            }else {
                int t = (int)obj;
                Image temp = ImageArray[i].transform.GetChild(1).GetComponent<Image>();
                Text text = ImageArray[i].transform.GetChild(1).Find("Text").GetComponent<Text>();
                Image PropPicture= ImageArray[i].transform.GetChild(0).GetComponent<Image>();
                ImageArray[i].gameObject.SetActive(true);
                if (t==0){
                    PropPicture.sprite = MultiplySpirte;
                }else if (t==1){
                    PropPicture.sprite = MagnetSprite;
                }else {
                    PropPicture.sprite = ShieldSprite;
                }
                PropPicture.SetNativeSize();
                StartCoroutine(SerFillAmount(5.0f, temp,text));
                break;
            }
        }
    }

    //进行FillAmount设置
    IEnumerator SerFillAmount(float time,Image image,Text text) {
        bool isFinish = false;
        float PropTime = 5.0f;
        float t = PropTime / 0.1f;
        t = 1 / t;
        while (!isFinish) {
            PropTime -= 0.1f;
            //float t = image.fillAmount / PropTime;
            
            yield return new WaitForSeconds(0.1f);
            if (PropTime<=0) {
                PropTime = 0;
                isFinish = true;
            }
            text.text = PropTime.ToString("f2");
            image.fillAmount -= t;
        }
        image.transform.parent.gameObject.SetActive(false);
        image.fillAmount = 1;


    }

    protected override void OnBeforeDestroy(){}
}
