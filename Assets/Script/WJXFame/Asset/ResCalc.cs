using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    //引用计数器
    static public class ResClac{
        static ushort ResCount=0;//引用计数器总数

       static public ushort GetResCount {
            get {
                return ResCount;
            }
        }

        //增加引用计数
        static public void AddResNum() {
            ++ResCount;
        }

        //引用计数减一
        static public void MinUsResNum() {
            --ResCount;
        }

        //引用计数设置为0
        static public void SetZeroFResNum(){
            ResCount = 0;
        }

        //增加任意数字
        static public void AddResNum(ushort _num) {
            ResCount += _num;
        }
    }
}


