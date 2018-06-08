using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//组合设置
public enum Combination:ushort {
    Default = 0x00,
    Combination1 =0x01<<1,
	Combination2=0x02<<2,
	Combination3=0x03<<3,
	Combination4=0x04<<4,
	Combination5=0x05<<5,
	Combination6=0x06<<6,
	Combination7=0x07<<7,
	Combination8=0x08<<8,
	Combination9=0x09<<9,
	Combination10=0x10<<10,
	Combination11=0x11<<11,
	Combination12=0x12<<10
}

//jie suo lei xing
public enum LockType{
	None,
	Iap,
	Video
}

public enum UnLockType{
	None,
	All,
	Full,
	Level,
	NoAds,
	TypeOne,
	TypeTwo,
}

//资源类型
enum ResourceType {
	Dragon,
	Sprite
}

public delegate void ToolEndDRAG(Vector3 _vec);

//有可能需要监听其他函数(无参数版)
public delegate void StateCFunc();

//有可能需要监听其他函数(带参数版(SpriteRenderer))
public delegate void StateCHFunc(SpriteRenderer _obj);

//
public delegate void StateCHFunc<T>(T _obj);

//UI监听函数
public delegate void UIFunc();

//UI监听函数，泛型
public delegate void UIFunc<T>(T _obj);