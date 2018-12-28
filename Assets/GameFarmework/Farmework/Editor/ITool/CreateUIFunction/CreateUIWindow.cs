using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateUIWindow : EditorWindow {
    [MenuItem("工具/创建UI源码窗口")]
    static void Inite() {

        //创建窗口
        CreateUIWindow window = GetWindow<CreateUIWindow>();

        //设置窗口位置和大小
        float PosX = Screen.width / 2.0f;
        float PosY = Screen.height / 2.0f;
        window.titleContent = new GUIContent("创建UI源码窗口");
        window.position =new Rect(new Vector2(PosX,PosY),new Vector2(300,130));
    }

    void OnGUI() {
        GUILayout.Label("自动创建UICcontroller,UIModel和UIPlane");
        GUILayout.Label("\n使用说明:\n   1.打开窗口后选择要挂UIController的对象;\n   2.选择要放置文件的文件夹;\n   3.点击创建按钮;");

        string path = null;

        string[] strs = Selection.assetGUIDs;
        if (strs.Length>0) {
            path = AssetDatabase.GUIDToAssetPath(strs[0]);
            path = path.Substring(6);
            GUILayout.Label("\n文件夹名:" + path);
            Repaint();
        }
       

        string objName = null;

        if (Selection.activeGameObject != null){
            objName = Selection.activeGameObject.name;
            GUILayout.Label("\n对象名:"+ objName);
        }

        if (GUILayout.Button("创建UI源码")) {
            if ((path != null) && (objName != null)){
                CreateSourceCode.CreateUISourceCode(path, objName);
                //刷新文件
                AssetDatabase.Refresh();
            }
            else {
                GUILayout.Label("\n请选择对象和文件夹名");
            }
           
        }
    }

    //每次点击对象时都会改变对象的名称
    void OnSelectionChange() {
        //刷新
        Repaint();
    }
}
