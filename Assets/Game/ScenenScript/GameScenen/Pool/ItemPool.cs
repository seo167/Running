using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class ItemPool : PoolBase
{
    string[] ItemName= {
        "Items/Block_Ai",
        "Items/Block_Ai_Yellow",
        "Items/Block_Big",
        "Items/Block_Car01",
        "Items/Block_DingZi",
        "Items/Block_Gao",
        "Items/Block_Gao_Yellow",
        "Items/Block_JiZhuangXiang",
        "Items/Block_JiZhuangXiangFloor",
        "Items/Block_JiZhuangXiangFloor01",
        "Items/Block_JiZhuangXiangFloorBlue",
        "Items/Block_JiZhuangXiangFloorBrown",
        "Items/Block_JiZhuangXiangFloorOrange",
        "Items/Block_ShuiNiGuan",
        "Items/Block_Zhong",
        "Items/Block_Zhong_Yellow",
        "Items/Block_Ai",
        "Items/Block_Ai_Yellow",
        "Items/Block_Big",
        "Items/Block_Car01",
        "Items/Block_DingZi",
        "Items/Block_Gao",
        "Items/Block_Gao_Yellow",
        "Items/Block_JiZhuangXiang",
        "Items/Block_JiZhuangXiangFloor",
        "Items/Block_JiZhuangXiangFloor01",
        "Items/Block_JiZhuangXiangFloorBlue",
        "Items/Block_JiZhuangXiangFloorBrown",
        "Items/Block_JiZhuangXiangFloorOrange",
        "Items/Block_ShuiNiGuan",
        "Items/Block_Zhong",
        "Items/Block_Zhong_Yellow",
         "Items/Block_Ai",
        "Items/Block_Ai_Yellow",
        "Items/Block_Big",
        "Items/Block_Car01",
        "Items/Block_DingZi",
        "Items/Block_Gao",
        "Items/Block_Gao_Yellow",
        "Items/Block_JiZhuangXiang",
        "Items/Block_JiZhuangXiangFloor",
        "Items/Block_JiZhuangXiangFloor01",
        "Items/Block_JiZhuangXiangFloorBlue",
        "Items/Block_JiZhuangXiangFloorBrown",
        "Items/Block_JiZhuangXiangFloorOrange",
        "Items/Block_ShuiNiGuan",
        "Items/Block_Zhong",
        "Items/Block_Zhong_Yellow"
    };

    List<GameObject> PatternList = new List<GameObject>();

    float[] mPosX = {
        -1.5f,
        0.0f,
        1.5f
    };

    float minZ = 20;
    float maxZ = 150;

    public GameObject GetObj(int num)
    {
        PatternList[num].gameObject.SetActive(true);
        return PatternList[num];
    }

    public ItemPool() {
        for (int i=0;i< ItemName.Length;++i) {
            IniteItemList(ItemName[i]);
        }
    }

    GameObject PrevObj;

    public void SetItem(){
        Transform Parent = PoolManager.Instace.GetPool<PatternPool>(PoolType.PATTERN).NowPattern.transform.Find("Item");
        for (int i = 0; i <20; ++i){
            int num = Random.Range(0, PatternList.Count);
            PatternList[num].gameObject.SetActive(true);
           
            PatternList[num].transform.parent = Parent;
            float x = mPosX[Random.Range(0, mPosX.Length)];
         

            if (PrevObj != null){
                if ((PrevObj.transform.localPosition.z + 15.0f) >= maxZ || (PrevObj.transform.localPosition.z + 10.0f) >= maxZ){
                    PrevObj = null;
                    break;
                }
                if (PrevObj.name.Contains("JiZhuangXiang")){
                    PatternList[num].transform.localPosition = new Vector3(x, 0, PrevObj.transform.localPosition.z + 15.0f);
                }else{
                    PatternList[num].transform.localPosition = new Vector3(x, 0, PrevObj.transform.localPosition.z + 10.0f);
                }
            }
            else {
                PatternList[num].transform.localPosition = new Vector3(x, 0, 20.0f);
            }

            
            PrevObj = PatternList[num];
        }
    }

    public void Clear(){
        for (int i = 0; i < PatternList.Count; ++i){
            GameObject.Destroy(PatternList[i]);
        }
        PatternList.Clear();
    }

    public void IniteItemList(string path)
    {
        GameObject Item = Resources.Load(path) as GameObject;
        Item = GameObject.Instantiate<GameObject>(Item);
        Item.transform.localPosition = Vector3.zero;
        Item.gameObject.SetActive(false);
        PatternList.Add(Item);
    }
}
