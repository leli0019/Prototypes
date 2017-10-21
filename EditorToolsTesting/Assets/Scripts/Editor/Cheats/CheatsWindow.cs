using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CheatsWindow : EditorWindow {

    [MenuItem("MyGame/Cheats")]
    public static void ShowWindow()
    {
        GetWindow<CheatsWindow>(false, "Cheats", true);
    }

    public void OnGUI()
    {
        //EditorGUILayout.Toggle("ToggleTest", false);
        //EditorGUILayout.IntField("IntTest", 3);
        //EditorGUILayout.TextField("TextTest" ,"HelloWorld");

        //Cheats.muteSounds = EditorGUILayout.Toggle("Test Mute", Cheats.muteSounds);
        //Cheats.playerLives = EditorGUILayout.IntField("Test Int", Cheats.playerLives);
        //Cheats.playerName = EditorGUILayout.TextField("Test Text", Cheats.playerName);

        Cheats.MuteAllSounds = EditorGUILayout.Toggle("Mute All Sounds", Cheats.MuteAllSounds);
        Cheats.PlayerLives = EditorGUILayout.IntField("Player Lives", Cheats.PlayerLives);
        Cheats.PlayerTwoName = EditorGUILayout.TextField("Player Two Name", Cheats.PlayerTwoName);


        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.backgroundColor = Color.red;

        if(GUILayout.Button("Reset",GUILayout.Width(100), GUILayout.Height(30)))
        {
            Cheats.MuteAllSounds = false;
            Cheats.PlayerLives = 4;
            Cheats.PlayerTwoName = "John";

            //Cheats.muteSounds = false;
            //Cheats.playerLives = 4;
            //Cheats.playerName = "Testing";
        }

        GUILayout.EndHorizontal();
    }


}
