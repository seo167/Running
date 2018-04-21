using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//场景状态
namespace WJX {
    public class ScenenState{

        //场景初始化
        public virtual void ScenenStart() {
            //......
        }

        //场景逻辑
        public virtual void ScenenLogic() {
            //.......
        }

        //场景结束
        public virtual void ScenenEnd() {
            //......
        }
    }
}


