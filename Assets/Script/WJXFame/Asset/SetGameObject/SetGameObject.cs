using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WJX {

    public enum ObjAssetType {
        IMAGE,
        MATERIAL,
        SPRITERENDERER
    }

    public class SetGameObject{
        //设置
        public void SetObject(ObjAssetType _objAssetType,string Key,GameObject _obj,LoadAsset<object> LA) {
            switch (_objAssetType) {
                case ObjAssetType.IMAGE:
                    Image ImageTemp=HasObjType<Image>(_obj);
                    ImageTemp.sprite = GetSprite(Key,LA);
                    ImageTemp.SetNativeSize();
                    break;
                case ObjAssetType.MATERIAL:
                    break;
                case ObjAssetType.SPRITERENDERER:
                    HasObjType<SpriteRenderer>(_obj);
                    SpriteRenderer SpriteRendererTemp = HasObjType<SpriteRenderer>(_obj);
                    SpriteRendererTemp.sprite= GetSprite(Key, LA);
                    break;
            }

            ResClac.MinUsResNum();

            //如果引用计算器小于零则置为0
            if (ResClac.GetResCount<0) {
                ResClac.SetZeroFResNum();
            }
        }

        //返回精灵图
        Sprite GetSprite(string key, LoadAsset<object> LA) {
            Texture2D texture2d = LA.GetObject(key) as Texture2D;
            Sprite SpriteTemp=null;
            if (texture2d!=null) {
                SpriteTemp = Sprite.Create(texture2d,new Rect(0,0,texture2d.width,texture2d.height),new Vector2(0.5f,0.5f));
            }
            return SpriteTemp;
        }

        //返回纹理
        Material GetMaterial(string key,LoadAsset<object> LA) {
            Material material = LA.GetObject(key) as Material;
            return material;
        }

        //用来判断是否拥有该挂件(如果没有会自行挂上)
        T HasObjType<T>(GameObject obj)where T:Component {
            T temp=null;
            if (obj.GetComponent<T>()==null) {
                temp=obj.AddComponent<T>();
            }
            return temp;
        }
    }
}


