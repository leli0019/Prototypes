using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MaterialEditor : Editor {

    static Material previousMat;
	
    public static void ApplyMaterial(GameObject go, Material mat)
    {
        if (go == null || mat == null)
            return;

         previousMat = go.GetComponent<Renderer>().sharedMaterial;
        //Undo.RecordObject(go,"Added Material:" + mat);
        Undo.RegisterCompleteObjectUndo(go,"Added Material");
        go.GetComponent<Renderer>().material = mat;

        EditorSceneManager.MarkAllScenesDirty();
    }
    public static void UndoMaterial(GameObject go)
    {

        go.GetComponent<Renderer>().material = previousMat;

    }

}
