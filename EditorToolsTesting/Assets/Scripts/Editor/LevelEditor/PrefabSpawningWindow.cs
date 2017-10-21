﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabSpawningWindow : EditorWindow {

    static int MaxPrefabsPerColumn = 0;
    static float prefabSize = 100;

    public static void ShowWindow()
    {
        EditorWindow window = GetWindow<PrefabSpawningWindow>(false, "Prefabs", true);
    }

    public void OnGUI()
    {
        MaxPrefabsPerColumn = (int)(position.width / prefabSize);
           
        DrawPrefabButtons();
    }

    static void DrawPrefabButtons()
    {
        

        GUILayout.BeginHorizontal();

        int prefabInColumn = 0;
        for (int i = 0; i < AddandRemoveObjects.m_levelObjects.objects.Count; i++)
        {
            if(prefabInColumn == MaxPrefabsPerColumn)
            {
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();

                prefabInColumn = 0;
            }
            DrawPrefabButton(i);

            prefabInColumn++;
        }
        GUILayout.EndHorizontal();

    }
    static void DrawPrefabButton(int index)
    {
        bool isActive = false;           

        if (index == AddandRemoveObjects.SelectedObject)        
            isActive = true;
        
        Texture2D previewImage = AssetPreview.GetAssetPreview(AddandRemoveObjects.m_levelObjects.objects[index].Prefab);      

        bool isToggleDown = GUILayout.Toggle(isActive, previewImage, GUI.skin.button ,GUILayout.Width(prefabSize), GUILayout.Height(prefabSize));


        if (isToggleDown == true && isActive == false)
        {
            AddandRemoveObjects.SelectedObject = index;
           // Debug.Log(AddandRemoveObjects.SelectedObject);

        }



    }
    private void OnDestroy()
    {
        Tools.DrawBoxHandle = false;
        SceneView.RepaintAll();
    } 

}
