using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class MaterialEditor : Editor {
    
    static List<GameObject> Gameobjects = new List<GameObject>();
    static List<Material> Materials = new List<Material>();

    public static void ApplyMaterials(Material mat)
    {
        ClearLists();

        foreach(GameObject go in Selection.gameObjects)
        {

            Transform[] allChildren = go.GetComponentsInChildren<Transform>();
            foreach(Transform child in allChildren)
            {
                Renderer r = child.gameObject.GetComponent<Renderer>();
                if (r == null)
                    continue;
                
                    Gameobjects.Add(child.gameObject);

                    Material m = r.sharedMaterial;
                    Materials.Add(m);

                    r.material = mat;
                
            }
            
        }

       // previousMat = go.GetComponent<Renderer>().sharedMaterial;
        //Undo.RecordObject(go,"Added Material:" + mat);
       // Undo.RegisterCompleteObjectUndo(go, "Added Material");
      //  go.GetComponent<Renderer>().material = mat;

        EditorSceneManager.MarkAllScenesDirty();
    }
    public static void UndoMaterials()
    {

        for (int i = 0; i < Gameobjects.Count; i++)
        {
            Gameobjects[i].GetComponent<Renderer>().material = Materials[i];
        }

        ClearLists();
    }

    static void ClearLists()
    {
        Gameobjects.Clear();
        Materials.Clear();
    }

}
