//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

////节点编辑器
//public class NodeEditorWindow : EditorWindow {

//    static NodeEditorWindow window;
//    List<NodeWindow> mNodeWindowList=new List<NodeWindow>();

//    Vector2 mMousePosition;

//    [MenuItem("工具/子节点编辑工具")]
//    static void Init() {
//        window = GetWindow<NodeEditorWindow>();
//        float PosX = Screen.width / 2.0f;
//        float PosY = Screen.height / 2.0f;
//        window.titleContent = new GUIContent("创建UI源码窗口");
//        window.position = new Rect(new Vector2(PosX, PosY), new Vector2(1400, 900));
//    }

//    private void OnGUI(){

//        //进行右键点击时，会出现菜单栏
//        Event e = Event.current;

//        /*
//            0为鼠标左键
//            1为鼠标右键
//            2为鼠标中建
//         */
//        mMousePosition = e.mousePosition;
//        if (e.button==1) {
//            GenericMenu menu = new GenericMenu();
//            menu.AddItem(new GUIContent("创建节点"),false,CreateMenuItem);
//            menu.ShowAsContext();
//            e.Use();
//        }

//        if (e.button == 0){
//            for (int i = 0; i < mNodeWindowList.Count; i++)
//            {


//            }

//        }

//        ShowWindow();

//    }

//    //显示子窗口
//    void ShowWindow() {
//        BeginWindows();

//        for (int i=0;i< mNodeWindowList.Count;++i){
//            GUI.Window(i,new Rect(mNodeWindowList[i].MousePosition, new Vector2(300,200)),WindowFunctionCallBack, new GUIContent("aaa"));
//        }

//        EndWindows();
//    }

//    void WindowFunctionCallBack(int id) {
//        Debug.Log(id);
//        mNodeWindowList[id].DrawWindow();
//        GUI.DragWindow(new Rect(0, 0, 10000, 20));
//    }

//    //创建节点子窗口
//    void CreateMenuItem() {
//        NodeWindow _NodeWindow = new NodeWindow();
//        _NodeWindow.MousePosition = mMousePosition;
//        mNodeWindowList.Add(_NodeWindow);
//    }

//}
