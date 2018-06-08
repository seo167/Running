using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WJX {
    //群组分散AI
    public class DisperseAI : ClusterAI{

        //分离时候的力
        Vector3 DisperseForce = Vector3.zero;

        Vector3 Translation;

        public DisperseAI(float mMoveSpeed, float mRotateSpeed, float mWeight, float mDistance, Transform mTransform, Vector3 mTranslation) 
            : base(mMoveSpeed,mRotateSpeed, mWeight,mDistance, mTransform) {
            Translation = mTranslation;
        }

        //距离计算
        public override void CalculateDistance() {
            if (_AIObjectList.Count>0) {
                float magnitude=0;
                for (int i=0;i<_AIObjectList.Count;++i) {
                    if ((_AIObjectList[i]!=null)&& (_AIObjectList[i].gameObject!=_Transform.gameObject)) {
                        Vector3 dir = _Transform.position - _AIObjectList[i].transform.position;
                        magnitude = dir.magnitude;
                        DisperseForce += dir.normalized / magnitude;
                    }
                }

                if (_Distance < magnitude){
                    DisperseForce *= _Weight;
                }
            }
           
        }

       
        public override void AIExcute(){
            Vector3 a = DisperseForce /3;
            Translation += a * Time.deltaTime;

            //计算旋转角度
            float angle= Vector3.Angle(_Transform.position, Translation);
            _Transform.rotation = Quaternion.Euler(0,0,-angle);

            //移动
            _Transform.Translate(Translation * _MoveSpeed,Space.World);
        }

    }
}


