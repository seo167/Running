using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WJX;

public class PatternPool : PoolBase {

    List<GameObject> PatternList=new List<GameObject>();

    Transform ObjParent;

    GameObject mNowPattern;

    GameObject mNextPattern;

    public GameObject NowPattern {
        set {
            mNowPattern = value;
        }
        get {
            return mNowPattern;
        }
    }

    public GameObject NextPattern {
        set {
            mNextPattern = value;
        }
        get {
            return mNextPattern;
        }
    }


    public PatternPool() {
        ObjParent = GameObject.Find("Pattern").transform;
        InitePatternList("Patterns/Pattern_1");
        InitePatternList("Patterns/Pattern_2");
        InitePatternList("Patterns/Pattern_3");
        InitePatternList("Patterns/Pattern_4");
    }

    public GameObject GetObj(int num) {
        PatternList[num].gameObject.SetActive(true);
        return PatternList[num];
    }

    public void SetPattern() {
        int num = Random.Range(0, PatternList.Count);

        float x = mNextPattern.transform.position.x;
        float y = mNextPattern.transform.position.y;
        float z = mNextPattern.transform.position.z;
        mNowPattern.SetActive(false);
        mNowPattern = mNextPattern;

        if (PatternList[num].activeSelf)
        {
            for (int i = 0; i < PatternList.Count; ++i)
            {
                if (PatternList[i].activeSelf){
                    continue;
                }

                PatternList[i].transform.localPosition = new Vector3(x, y, z + 160.0f);
                PatternList[i].gameObject.SetActive(true);
                mNextPattern = PatternList[i];
                break;
            }
        }
        else {
            PatternList[num].transform.localPosition = new Vector3(x, y, z + 160.0f);
            PatternList[num].gameObject.SetActive(true);
            mNextPattern = PatternList[num];
        }
      
    }

    public void Clear(){
        for (int i=0;i< PatternList.Count;++i) {
            GameObject.Destroy(PatternList[i]);
        }
        PatternList.Clear();
    }

    void InitePatternList(string path) {
        GameObject Pattern = Resources.Load(path) as GameObject;
        Pattern = GameObject.Instantiate<GameObject>(Pattern, ObjParent);
        Pattern.transform.localPosition = Vector3.zero;
        Pattern.transform.parent = ObjParent;
        Pattern.gameObject.SetActive(false);
        PatternList.Add(Pattern);
    }
}
