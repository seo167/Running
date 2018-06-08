﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX
{
public static class DictionaryExtension  {

        public static Tvalue TryGet<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key)
        {
            Tvalue value;
            dict.TryGetValue(key, out value);
            return value;
        }

    }
}


