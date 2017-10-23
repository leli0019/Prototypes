using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MissionEditorWindow : EditorWindow
{
    static int SelectedObjective = 0;

    static string objectiveName = string.Empty;
    static GameObject player = null;
    static GameObject target = null;
    static float radius = 0;

    static Rect LeftBox;
    static Rect CenterBox;
    static Rect RightBox;


    [MenuItem("VRtualEclipse/Mission Editor")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow<MissionEditorWindow>(false, "Mission Editor", true);
        window.minSize = new Vector2(500, 500);
    }

   

    private void OnGUI()
    {
        LeftBox = new Rect(0, 5, 110, position.height - 10);
        CenterBox = new Rect(LeftBox.xMax + 10, LeftBox.yMin, position.width, LeftBox.height);

        GUILayout.BeginArea(LeftBox, EditorStyles.helpBox);
        GUIStyle style = new GUIStyle();
        style.richText = true;

        GUILayout.Label("<size=15><b> Objectives </b> </size>", style);

        string[] labels = new string[] { "Proximity", "Goal" ,"Custom" };
        SelectedObjective = GUILayout.SelectionGrid(SelectedObjective, labels, 1, GUILayout.Height(25 * labels.Length));
        //if (GUILayout.Button("Proximity", GUILayout.Width(100), GUILayout.Height(25)))
        //{
        //    ObjectiveEditor.CreateObjective<ProximityObjective>();
        //}
        //if (GUILayout.Button("Custom", GUILayout.Width(100), GUILayout.Height(25)))
        //{
        //    ObjectiveEditor.CreateObjective<ProximityObjective>();
        //}

        GUILayout.EndArea();
        // GUILayout.EndVertical();

        GUILayout.BeginArea(CenterBox, EditorStyles.helpBox);

        switch (SelectedObjective)
        {
            case 0:
                DrawProximity();
                break;

            case 1:
                DrawGoal();
                break;

        }
       
        GUILayout.EndArea();
    }

    static void DrawProximity()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        GUILayout.Label("<size=30><b> Proximity </b> </size>", style);

        GUILayout.Space(15);
        objectiveName = EditorGUILayout.TextField("ObjectiveName" , objectiveName, GUILayout.Width(332));
        player = (GameObject)EditorGUILayout.ObjectField("Player", player, typeof(GameObject), true, GUILayout.Width(350));
        target = (GameObject)EditorGUILayout.ObjectField("Target", target, typeof(GameObject), true, GUILayout.Width(350));
        radius = EditorGUILayout.FloatField("ZoneRadius", radius, GUILayout.Width(332));
        GUILayout.Space(30);

        ObjectiveEditor.MyParent = (Transform)EditorGUILayout.ObjectField("Parent", ObjectiveEditor.MyParent, typeof(Transform), true, GUILayout.Width(350));
        GUILayout.BeginHorizontal();
        GUILayout.Space(150);
        if (GUILayout.Button("Create Objective", GUILayout.Width(180), GUILayout.Height(30)))
        {
            ObjectiveEditor.CreateProximityObjective(objectiveName, player, target, radius);
        }


        GUILayout.EndHorizontal();

    }

    static void DrawGoal()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        GUILayout.Label("<size=30><b> Goal </b> </size>", style);

        GUILayout.Space(15);
        objectiveName = EditorGUILayout.TextField("Goal Name", objectiveName, GUILayout.Width(332));
        player = (GameObject)EditorGUILayout.ObjectField("Player", player, typeof(GameObject), true, GUILayout.Width(350));
        GUILayout.Space(30);

        ObjectiveEditor.MyParent = (Transform)EditorGUILayout.ObjectField("Parent", ObjectiveEditor.MyParent, typeof(Transform), true, GUILayout.Width(350));
        GUILayout.BeginHorizontal();
        GUILayout.Space(150);
        if (GUILayout.Button("Create Goal", GUILayout.Width(180), GUILayout.Height(30)))
        {
            ObjectiveEditor.CreateGoal(objectiveName, player);
        }


        GUILayout.EndHorizontal();

    }

}
