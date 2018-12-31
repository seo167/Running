using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class StreetPool : MonoBehaviourSimply {

    [SerializeField] List<Street> s;
    Street NowStreet;
    Street PrevStreet;

    private void Awake(){
        RegisterMsg("StreetPool",ChangeStreet);
        ChangeStreet(Vector3.zero);
    }

    void ChangeStreet(object obj) {
        if (NowStreet!=null) {
            PrevStreet = NowStreet;
        }

        int index = Random.Range(0,s.Count);

        NowStreet = s[index];
        NowStreet.gameObject.SetActive(true);
        NowStreet.Reset();
        s.Remove(NowStreet);
        if(PrevStreet != null){
            DelayCoroutine(60.0f, () =>{
                PrevStreet.gameObject.SetActive(false);
            });
            Vector3 t = PrevStreet.gameObject.transform.localPosition;
            t.z += 160.0f;
            NowStreet.transform.localPosition = t;
            s.Add(PrevStreet);
        }else{
            if (obj == null){
                Vector3 t = (Vector3)obj;
                NowStreet.transform.localPosition = t;
            }
        }
    }

    protected override void OnBeforeDestroy(){
        s.Clear();
    }

}
