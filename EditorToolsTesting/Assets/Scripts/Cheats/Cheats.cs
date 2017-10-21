using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


//public class Cheats : MonoBehaviour
//{

//    public static bool muteSounds = false;
//    public static int playerLives = 4;
//    public static string playerName = "Test";



//}


public class Cheats
{
    public static bool MuteAllSounds
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetBool("MuteAllSounds", false);
#else
            return false;
#endif
        }

        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetBool("MuteAllSounds", value);
#endif
        }
    }

    public static int PlayerLives
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetInt("PlayerLives", 3);
#else
            return false;
#endif
        }

        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetInt("PlayerLives", value);
#endif
        }
    }

    public static string PlayerTwoName
    {
        get
        {
#if UNITY_EDITOR
            return EditorPrefs.GetString("PlayerTwoName", "John");
#else
            return false;
#endif
        }

        set
        {
#if UNITY_EDITOR
            EditorPrefs.SetString("PlayerTwoName", value);
#endif
        }
    }
}