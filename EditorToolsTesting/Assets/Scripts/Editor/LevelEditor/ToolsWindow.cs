using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolsWindow : EditorWindow {

    [MenuItem("VRtualEclipse/Level Editor")]
	public static void ShowWindow()
    {
        GetWindow<ToolsWindow>(false, "Level Editor", true);
    }

    public void OnGUI()
    {
        GUIStyle style = GUI.skin.button;


        // Tools.DrawBoxHandle = EditorGUILayout.Toggle("Create Objects", Tools.DrawBoxHandle , GUI.skin.button);
         Tools.isLevelEditorEnabled = GUILayout.Button("Create Prefabs", GUILayout.Height(30.0f));

        if (Tools.isLevelEditorEnabled)
        {
            PrefabSpawningWindow.ShowWindow();
            this.Close();
        }          


        //SceneView.RepaintAll();
    }

}
