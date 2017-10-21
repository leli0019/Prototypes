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
        Tools.DrawBoxHandle = EditorGUILayout.Toggle("Create Objects", Tools.DrawBoxHandle);

        SceneView.RepaintAll();
    }

}
