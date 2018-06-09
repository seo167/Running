using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WJX;

public class CameraController : UIController {

    CameraView _CameraView;

    CameraModel _CameraModel;

    public CameraController(CameraView _Camera,CameraModel _model) {
        _CameraView = _Camera;
        _CameraModel = _model;
    }

    //主要逻辑执行
    public override void ControllerLogic(){
        _CameraView.Begin(_CameraModel.ChangeSpeed,SetDistance);
    }

    //计算摄像机和目标对象的距离
    void SetDistance() {
        _CameraModel.Distance = _CameraView.GetTarget.position.z - _CameraView.transform.position.z;
        _CameraView.Logic(UIManager.Instace.GetControllerForT<PlayerController>(UIType.PLAYER).GetPlayerModel.Speed,_CameraModel.Distance);
        UIManager.Instace.UILogic(UIType.PLAYER);
    }

}

public class CameraModel : UIModel {
    //存储默认位置
    Matrix4x4 _Matrix4x4;

    public Matrix4x4 GetMatrix4x4 {
        get {
            return _Matrix4x4;
        }
    }

    bool _isMove = true;

    public bool IsMove {
        get {
            return _isMove;
        }
        set {
            _isMove = value;
        }
    }

    //目标与摄像机的z轴距离
    float distance;

    public float Distance {
        get {
            return distance;
        }
        set {
            distance = value;
        }
    }


    float changeSpeed=1.5f;

    public float ChangeSpeed {
        get {
            return changeSpeed;
        }
    }


    /// <summary>
    /// 传入相机默认位置
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="scale"></param>
    public CameraModel(Vector4 position,Vector4 rotation) {
        _Matrix4x4 = new Matrix4x4();
        _Matrix4x4.SetRow(0,position);
        _Matrix4x4.SetRow(1,rotation);
    }

}

public class CameraView : UIPlane {

    Transform target;//目标

    public Transform GetTarget {
        get {
            return target;
        }
    }

    protected override void Awake(){
        CameraView temp = GetComponent<CameraView>();
        CameraModel modeltemp = new CameraModel(transform.position,transform.eulerAngles);
        target = GameObject.Find("Player").transform;
        UIManager.Instace.RegisterController(UIType.CAMERA, new CameraController(temp, modeltemp));
       
    }

    public void Begin(float speed,UnityAction _Action = null){
        StartCoroutine(Change(_Action, speed));

    }

    //摄像机跟随目标移动
    public void Logic(float speed,float distance){
        StartCoroutine(MoveForTarget(speed,distance));
    }

    //跟随目标移动
    IEnumerator MoveForTarget(float speed, float distance) {
        while (true) {
            float z = target.position.z - distance;
            float y = transform.position.y;
            float x = transform.position.x;
            transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, z), speed * Time.deltaTime);
            yield return null;
        }
    }


    //修改摄像机方向和角度
    IEnumerator Change(UnityAction _Action,float speed) {

        yield return new WaitForSeconds(0.5f);

        while (true) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 4.5f, -5), speed * Time.deltaTime);
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.Euler(20.0f,0.0f,0.0f), 10*speed* Time.deltaTime);
            yield return null;

            float y = transform.position.y;
            float z = transform.position.z;

            if (Mathf.Abs(y-4.5f)<=0.1f||Mathf.Abs(z-5)<=0.1f) {
                transform.rotation = Quaternion.Euler(20,0,0);
               break;
            }
        }

        if (_Action != null){
            _Action.Invoke();
        }
    }

}
