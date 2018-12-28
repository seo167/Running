using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Farmework {

    public interface IPool<T> {
        T Allocate(string name);
        void Recyle(T obj);
    }

    //对象创建
    public interface ObjFactory<T> {
        T Create(string name);
    }

    //对象工厂
    public class Factory<T> : ObjFactory<T> {
        Func<string,T> factoryMethod;
        public void SetFactoryFunc(Func<string,T> _method) {
            factoryMethod = _method;
        }

        public T Create(string name) {
            return factoryMethod(name);
        }
    }

    public abstract class Pool<T>:IPool<T>{
        int _MaxCount=5;//缓存数量

        public int MaxCount {
            get {
                return _MaxCount;
            }
            set {
                _MaxCount = value;
            }
        }

        protected Factory<T> _factory=new Factory<T>();

        protected static Stack<T> PoolStack = new Stack<T>();

        public T Allocate(string name=null) {
            return (PoolStack.Count>0)? PoolStack.Pop(): _factory.Create(name);
        }

        public abstract void Recyle(T obj);
    }

    public class PoolManager<T> : Pool<T> {

        Action<T> ReSetMethod;

        public PoolManager(Func<string,T> funcMethod,Action<T> _ReSetMethod=null){
            _factory.SetFactoryFunc(funcMethod);
            ReSetMethod = _ReSetMethod;
        }


        public override void Recyle(T obj) {

            if (ReSetMethod!=null) {
                ReSetMethod(obj);
            }

            if (PoolStack.Count<MaxCount) {
                PoolStack.Push(obj);
            }
        }



    }

}
