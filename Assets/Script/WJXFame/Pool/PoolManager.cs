using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class PoolManager{
        private static PoolManager _PoolManager;

        Dictionary<PoolType, PoolBase> PoolDictionary;

        public static PoolManager Instace {
            get {
                if (_PoolManager==null) {
                    _PoolManager = new PoolManager();
                }

                return _PoolManager;
            }
        }

        private PoolManager() {
            PoolDictionary = new Dictionary<PoolType, PoolBase>();
        }

        public T GetPool<T>(PoolType _poolType) where T : PoolBase {
            if (!PoolDictionary.ContainsKey(_poolType)) {
                return default(T);
            }
            return (T)PoolDictionary[_poolType];
        }

        public void RegisterPool(PoolType _poolType,PoolBase _base) {
            PoolDictionary.Add(_poolType,_base);
        }

        public void Clear(PoolType _poolType) {
            if (PoolDictionary.ContainsKey(_poolType)) {
                PoolDictionary[_poolType].Clear();
            }
        }

        public void ClearPool() {
            foreach (PoolBase b in PoolDictionary.Values) {
                b.Clear();
            }
        }

    }
}


