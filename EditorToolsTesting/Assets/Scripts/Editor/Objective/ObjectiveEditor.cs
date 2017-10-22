using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[InitializeOnLoad]
public class ObjectiveEditor : Editor
{

    static ScriptableObjective scriptableObjective;

    static Transform baseMission;
    public static Transform BaseMission
    {
        get
        {
            if (baseMission == null)
            {
                baseMission = GameObject.FindGameObjectWithTag("Mission").transform;
            }
            return baseMission;
        }
    }

    //static ObjectiveEditor()
    //{
    //    SceneView.onSceneGUIDelegate -= OnSceneGUI;
    //    SceneView.onSceneGUIDelegate += OnSceneGUI;

    //    //  scriptableObjective = AssetDatabase.LoadAssetAtPath<ScriptableObjective>("Assets/Scripts/ScriptableObjects/Objective/ZoneObjective.asset");
    //}


    //static void OnSceneGUI(SceneView sceneView)
    //{

    //}   

    public static void CreateProximityObjective(string name,GameObject player, GameObject target, float radius)
    {
        GameObject objective = new GameObject();
        objective.name = name;
        objective.transform.SetParent(BaseMission);

        ProximityObjective po = objective.AddComponent<ProximityObjective>();
        po.Player = player;
        po.Target = target;
        po.ZoneRadius = radius;

        if (po.Target.GetComponent<RadiusGizmo>() == null)
        {
            RadiusGizmo gizmo = po.Target.AddComponent<RadiusGizmo>();
            gizmo.radius = radius;
        }
        Undo.RegisterCreatedObjectUndo(objective, "Add " + objective.name);
        UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
    }


}
