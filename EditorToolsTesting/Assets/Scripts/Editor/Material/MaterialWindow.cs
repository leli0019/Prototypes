using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialWindow : EditorWindow

{
    static Material material;
    static Editor matEditor;

    static GameObject gameObjects;

    [MenuItem("VRtualEclipse/Material Editor")]
    public static void ShowWindow()
    {
       EditorWindow window = GetWindow<MaterialWindow>(false, "Material Window", true);
        window.minSize = new Vector2(410,210);
        window.maxSize = new Vector2(410,210);
    }


    //private void OnDisable()
    //{
    //    MaterialEditor.ClearLists();
    //}

    private void OnGUI()
    {


        GUILayout.BeginArea(new Rect(5,5,400,200), EditorStyles.helpBox);

        GUILayout.BeginVertical();

        material = (Material)EditorGUILayout.ObjectField("Material", material, typeof(Material), true, GUILayout.Width(350));
      
        GUILayout.Space(30);

        if (material != null)
            if (matEditor == null)
                matEditor = Editor.CreateEditor(material);

        if (material)
            matEditor.OnPreviewGUI(GUILayoutUtility.GetRect(15, 100), "Window");

        GUILayout.BeginHorizontal();
        if (material)
        {
            if (GUILayout.Button("Apply Material", GUILayout.Width(190), GUILayout.Height(30)))
            {
                   MaterialEditor.ApplyMaterials(material);

            }
            if (GUILayout.Button("Undo Material", GUILayout.Width(190), GUILayout.Height(30)))
            {
                 MaterialEditor.UndoMaterials();

            }
        }

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.EndArea();

        //GUILayout.BeginHorizontal();
        //GUILayout.Space(350);

       


        //GUILayout.EndHorizontal();


    }


}
