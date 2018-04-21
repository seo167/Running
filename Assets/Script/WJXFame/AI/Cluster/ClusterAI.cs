using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    A:加速度
    M:质量
    F:物体加速度的力
    牛顿第二定律:F=MA
    可以获得F/M=A

    群组AI需要：
    移动速度,旋转速度,三种权重：队列权重，分散权重，单独移出权重
*/

namespace WJX {
    //群组AI
    public class ClusterAI{
        protected float _MoveSpeed;//移动速度
        protected float _RotateSpeed;//旋转速度
        protected float _Weight;//权重
        protected float _Distance;//距离判断(主要用来做碰撞检测)
        protected List<GameObject> _AIObjectList;//用来存储需要检查的对象
        protected Transform _Transform;

        public ClusterAI(float mMoveSpeed,float mRotateSpeed,float mWeight,float mDistance, Transform mTransform) {
            _MoveSpeed = mMoveSpeed;
            _RotateSpeed = mRotateSpeed;
            _Weight = mWeight;
            _Distance = mDistance;
            _Transform = mTransform;
            _AIObjectList = new List<GameObject>();
        }

        public virtual void CalculateDistance() {

        }

        //获取2D对象
        public void GetColliderF2D(int layerMask) {
            _AIObjectList.Clear();
            Collider2D[] _Collider=Physics2D.OverlapCircleAll(_Transform.position,6);
            if (_Collider.Length>0) {
                for (int i=0;i<_Collider.Length;++i) {
                    _AIObjectList.Add(_Collider[i].gameObject);
                }
            }
        }

        //获取3D碰撞对象
        public void GetCollider() {
            _AIObjectList.Clear();
            Collider[] _Collider = Physics.OverlapSphere(_Transform.position, _Distance);
            if (_Collider.Length > 0){
                for (int i = 0; i < _Collider.Length; ++i)
                {
                    _AIObjectList.Add(_Collider[i].gameObject);
                }
            }
        }

        //要执行的AI算法(以后可能会有一个继承AI父类)
        public virtual void AIExcute(){
            //....
        }
    }
}


