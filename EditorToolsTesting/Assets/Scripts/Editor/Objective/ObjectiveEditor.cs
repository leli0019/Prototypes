using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[InitializeOnLoad]
public class ObjectiveEditor : Editor
{

    static ScriptableObjective scriptableObjective;

    static Transform myParent;
    public static Transform MyParent
    {
        get
        {
            if (myParent == null)
            {
                myParent = GameObject.FindGameObjectWithTag("Mission").transform;
            }
            return myParent;
        }
        set { myParent = value; }
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
        objective.transform.SetParent(MyParent);

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

    public static void CreateGoal(string name, GameObject player)
    {
        GameObject goal = new GameObject();
        goal.name = name;
        goal.transform.SetParent(MyParent);

        GetToProbeGoal component = goal.AddComponent<GetToProbeGoal>();
        component.Player = player;

        GameObject driverlist = new GameObject();
        driverlist.transform.SetParent(goal.transform);
        driverlist.name = "DriverObjectives";

        GameObject navigatorList = new GameObject();
        navigatorList.transform.SetParent(goal.transform);
        navigatorList.name = "NavigatorObjectives";

        GameObject scientistList = new GameObject();
        scientistList.transform.SetParent(goal.transform);
        scientistList.name = "ScientistObjectives";

    }


}
