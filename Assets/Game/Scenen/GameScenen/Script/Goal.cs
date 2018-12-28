using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Farmework;
public class Goal : MonoBehaviourSimply {
    [SerializeField]Animation QiuMenAnimation;
    [SerializeField] GameObject _Goal;
    Animation ShouMenYuanAnimation;

    public GameObject GetGoal {
        get {
            return _Goal;
        }
    }

    private void Awake(){
        RegisterObj();
        RegisterMsg("Goal", GoalKeeper);
        ShouMenYuanAnimation = _Goal.GetComponent<Animation>();
    }

    public void GoalKeeper(object obj) {
        int BallDirection = (int)obj;
        switch (BallDirection) {
            case -1:
                ShouMenYuanAnimation.Play("right_flutter");
                break;
            case 0:
                ShouMenYuanAnimation.Play("flutter");
                break;
            case 1:
                ShouMenYuanAnimation.Play("left_flutter");
                break;
        }
        DelayCoroutine(1.0f,()=> {
            SetObject.Hide(_Goal);
        });
    }

    protected override void OnBeforeDestroy()
    {

    }
}
