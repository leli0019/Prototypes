using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class EditorHandles : Editor {

    public static Vector3 currentHandlePos = Vector3.zero;
    public static bool isMouseInValidArea = true;

    private static Vector3 oldHandlePos = Vector3.zero;


    static EditorHandles()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;

    }

    private void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {

        bool isLevelEditorEnabled = EditorPrefs.GetBool("IsLevelEditorEnabled", true);

        if(isLevelEditorEnabled == false)        
            return;
        

        if (Tools.SelectedLevelEditorTool == 0)
            return;

        UpdateHandlePosition();
        UpdateIsMouseInValidArea(sceneView.position);
        UpdateRepaint();

        DrawCubeDrawPreview();
    }

    static void UpdateIsMouseInValidArea(Rect sceneViewRect)
    {
        //Check if mouse is in a valid area
    }

    static void UpdateHandlePosition()
    {
        if (Event.current == null)
            return;

        if (EditorPrefs.GetBool("IsLevelEditorEnabled", false) == false)
            return;


            Vector2 currentMousePos = new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y);

        Ray ray = HandleUtility.GUIPointToWorldRay(currentMousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,Mathf.Infinity,1 << LayerMask.NameToLayer("Level")) == true)
        {
            Vector3 offset = Vector3.zero;

            
                //offset = hit.normal;

                //currentHandlePos.x = Mathf.Floor(hit.point.x - hit.normal.x * 0.001f + offset.x);
                //currentHandlePos.y = Mathf.Floor(hit.point.y - hit.normal.y * 0.001f + offset.y);
                //currentHandlePos.z = Mathf.Floor(hit.point.z - hit.normal.z * 0.001f + offset.z);

                //currentHandlePos += new Vector3(0.5f, 0.5f, 0.5f);
                
                currentHandlePos = hit.point;
            

        }


    }

    static void UpdateRepaint()
    {
        if(currentHandlePos != oldHandlePos)
        {
            SceneView.RepaintAll();
            oldHandlePos = currentHandlePos;
        }
    }

    static void DrawCubeDrawPreview()
    {
        if (isMouseInValidArea == false)        
            return;

        Handles.color = Color.green;
        DrawHandlesCube(currentHandlePos);

        
    }

    static void DrawHandlesCube(Vector3 center)
    {
        Vector3 p1 = center + Vector3.up * 0.5f + Vector3.right * 0.5f + Vector3.forward * 0.5f;
        Vector3 p2 = center + Vector3.up * 0.5f + Vector3.right * 0.5f - Vector3.forward * 0.5f;
        Vector3 p3 = center + Vector3.up * 0.5f - Vector3.right * 0.5f - Vector3.forward * 0.5f;
        Vector3 p4 = center + Vector3.up * 0.5f - Vector3.right * 0.5f + Vector3.forward * 0.5f;

        Vector3 p5 = center - Vector3.up * 0.5f + Vector3.right * 0.5f + Vector3.forward * 0.5f;
        Vector3 p6 = center - Vector3.up * 0.5f + Vector3.right * 0.5f - Vector3.forward * 0.5f;
        Vector3 p7 = center - Vector3.up * 0.5f - Vector3.right * 0.5f - Vector3.forward * 0.5f;
        Vector3 p8 = center - Vector3.up * 0.5f - Vector3.right * 0.5f + Vector3.forward * 0.5f;

      
        Handles.DrawLine(p1, p2);
        Handles.DrawLine(p2, p3);
        Handles.DrawLine(p3, p4);
        Handles.DrawLine(p4, p1);

        Handles.DrawLine(p5, p6);
        Handles.DrawLine(p6, p7);
        Handles.DrawLine(p7, p8);
        Handles.DrawLine(p8, p5);

        Handles.DrawLine(p1, p5);
        Handles.DrawLine(p2, p6);
        Handles.DrawLine(p3, p7);
        Handles.DrawLine(p4, p8);
    }

}
