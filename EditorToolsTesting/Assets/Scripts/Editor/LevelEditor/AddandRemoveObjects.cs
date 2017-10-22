﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class AddandRemoveObjects : Editor {

    static Transform m_levelParent;
    public static Transform LevelParent
    {
        get
        {
            if(m_levelParent == null)
            {
                GameObject go = GameObject.Find("Level");
               
                if(go != null)
                {
                    m_levelParent = go.transform;
                }
            }

            return m_levelParent;
        }
        
    }

    public static int SelectedObject
    {
        get
        {
            return EditorPrefs.GetInt("SelectedObject", 1);
        }
        set
        {
            EditorPrefs.SetInt("SelectedObject", value);
        }
    }

    static public LevelObjects m_levelObjects;

    static AddandRemoveObjects()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;

        m_levelObjects = AssetDatabase.LoadAssetAtPath<LevelObjects>( "Assets/Scripts/ScriptableObjects/LevelObject/LevelObjects.asset");

    }

    private void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        if (m_levelObjects == null)
            return;

        if (EditorPrefs.GetBool("IsLevelEditorEnabled", false) == false)
            return;
        
       // DrawCustomObjectButtons(sceneView);
        HandleLevelEditorPlacement();
       // DrawToolsMenu(sceneView.position);

    }

    static void HandleLevelEditorPlacement()
    {
        //if (EditorPrefs.GetBool("IsLevelEditorEnabled", false) == false)
        //    return;    

        if (Tools.SelectedLevelEditorTool == 0)
            return;


        int controlId = GUIUtility.GetControlID(FocusType.Passive);

        if (Event.current.type == EventType.mouseDown &&
            Event.current.button == 0 &&
            Event.current.alt == false &&
            Event.current.shift == false &&
            Event.current.control == false)
        {
            switch(Tools.SelectedLevelEditorTool)
            {             

                case 1:
                    RemoveObject(EditorHandles.currentHandlePos);
                    break;

                case 2:
                    if (SelectedObject < m_levelObjects.objects.Count)
                        AddObject(EditorHandles.currentHandlePos, m_levelObjects.objects[SelectedObject].Prefab);
                    break;
            }

            
        }


        HandleUtility.AddDefaultControl(controlId);
    }

     static void DrawCustomObjectButtons(SceneView sceneView)
    {
        Handles.BeginGUI();

        GUI.Box(new Rect(0, 0, 110, sceneView.position.height - 35), GUIContent.none, EditorStyles.textArea);
        for (int i = 0; i < m_levelObjects.objects.Count; ++i)
        {
            DrawCustomObjectButton(i ,sceneView.position );
        }

        Handles.EndGUI();
    }


    static void DrawCustomObjectButton(int index, Rect sceneViewRect)
    {
        bool isActive = false;

        if(EditorPrefs.GetBool("IsLevelEditorEnabled", false) && index == SelectedObject)
        {
            isActive = true;
        }

        Texture2D previewImage = AssetPreview.GetAssetPreview(m_levelObjects.objects[index].Prefab);
        GUIContent buttonContent = new GUIContent(previewImage);

        GUI.Label(new Rect(5, index * 128 + 5, 100, 20), m_levelObjects.objects[index].Name);
        bool isToggleDown = GUI.Toggle(new Rect(5, index * 128 + 25, 100, 100), isActive, buttonContent, GUI.skin.button);

        if (isToggleDown == true && isActive == false)
        {
            SelectedObject = index;
        }

    }
    public static void AddObject(Vector3 pos , GameObject prefab)
    {
        if (prefab == null)
            return;

        GameObject newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        newObject.transform.SetParent(LevelParent);
        newObject.transform.position = pos;

        Undo.RegisterCreatedObjectUndo(newObject, "Create " + prefab.name);

        UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();

    }

    public static void RemoveObject(Vector3 pos)
    {
        if (m_levelParent.childCount <= 0)
            return; 

        for (int i = 0; i < m_levelParent.childCount; i++)
        {

            float distanceToObject = Vector3.Distance(m_levelParent.GetChild(i).transform.position, pos);
            if(distanceToObject < 1.0f)
            {
                Undo.DestroyObjectImmediate(m_levelParent.GetChild(i).gameObject);

                UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
                return;
            }
        }
    }





}
