using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialWindow : EditorWindow

{
    static Material material;
    static Editor matEditor;

    static GameObject[] gameObjects = new GameObject[] { };

    [MenuItem("VRtualEclipse/Material Editor")]

    public static void ShowWindow()
    {
        GetWindow<MaterialWindow>(false, "Material Window", true);
    }


    private void OnGUI()
    {

       //// GUILayout.BeginVertical();

       
        
       //     //for (int i = 0; i < gameObjects.Length; i++)
       //     //{
       //     //    gameObjects[i] = (GameObject)EditorGUILayout.ObjectField("Gameobject", gameObjects[i], typeof(GameObject), true, GUILayout.Width(350));
       //     //}
        
        

       //// GUILayout.EndVertical();
       // if (!(material = (Material)EditorGUILayout.ObjectField("Material", material, typeof(Material), true, GUILayout.Width(350))))
       // {
       // }
       // GUILayout.Space(350);

       

       // if (material != null)       
       //     if (matEditor == null)            
       //         matEditor = Editor.CreateEditor(material);

       // if (material)
       //     matEditor.OnPreviewGUI(GUILayoutUtility.GetRect(15, 100), "Window");


       // GUILayout.EndHorizontal();

       // GUILayout.BeginHorizontal();
       // GUILayout.Space(350);

       // if(material)
       // if (GUILayout.Button("Apply Material", GUILayout.Width(150), GUILayout.Height(30)))
       // {
       //         foreach(GameObject go in gameObjects)
       //              MaterialEditor.ApplyMaterial(go, material);

       // }
       // if(material)
       // if (GUILayout.Button("Undo Material", GUILayout.Width(150), GUILayout.Height(30)))
       // {
       //    // MaterialEditor.UndoMaterial(gameObjects);

       // }


       // GUILayout.EndHorizontal();


    }


}
