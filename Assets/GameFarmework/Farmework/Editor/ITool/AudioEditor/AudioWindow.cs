using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class AudioWindow : EditorWindow {
    [MenuItem("工具/音效资源配置")]
    static void Init() {
        //创建音频弹窗
        AudioWindow window = EditorWindow.GetWindow<AudioWindow>();
        float PosX = Screen.width / 2.0f;
        float PosY = Screen.height / 2.0f;
        window.titleContent = new GUIContent("音效配置弹窗");
        window.position = new Rect(new Vector2(PosX, PosY), new Vector2(800, 500));

        FindFloder();

    }

    void OnGUI(){
        GUILayout.Label("会自动在Game中创建一个Audio文件和Common文件");
        GUILayout.Label("\n使用说明:\n   1.打开窗口后选择要挂UIController的对象;\n   2.选择要放置文件的文件夹;\n   3.点击创建按钮;");

        if (GUILayout.Button("配置音频")){

        }
    }

   static void FindFloder() {
        string _Path = Application.dataPath + "/Game/Audio";

        if (Directory.Exists(_Path)){
            if (!Directory.Exists(_Path + "/Common")) {
                Debug.Log("存在Audio文件夹，创建Common文件夹中，该文件夹用来放置公共音效资源");
                Directory.CreateDirectory(_Path + "/Common");
            }

            if (!Directory.Exists(_Path + "/" + SceneManager.GetActiveScene().name))
            {
                Debug.Log("自动创建关卡名文件中");
                Directory.CreateDirectory(_Path + "/" + SceneManager.GetActiveScene().name);
            }
        }
        else {
            Debug.Log("不存在Audio文件，自动创建中");
            Directory.CreateDirectory(_Path);
            FindFloder();
        }

        AssetDatabase.Refresh();
   }
    
   //查找关卡文件中是否存有音频文件
   static void FindScenenFloder(string path) {
        //DirectoryInfo dir = new DirectoryInfo(path);

        //FileSystemInfo[] _FileSystemInfo = dir.GetFileSystemInfos();
    }
}
