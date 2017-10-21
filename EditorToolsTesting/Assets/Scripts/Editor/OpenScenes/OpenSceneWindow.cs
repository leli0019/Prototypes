using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class OpenSceneWindow : EditorWindow {

    [MenuItem("Open Scene/Menu")]
    public static void OpenGameScene()
    {
        OpenScene("Menu");
    }
    [MenuItem("Open Scene/GameScene")]
    public static void OpenMenuScene()
    {
        OpenScene("GameScene");
    }


    private static void OpenScene(string scene)
    {
        if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Scenes/"+ scene + ".unity" , OpenSceneMode.Single);
        }
       // if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
    }


}
