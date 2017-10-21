using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tools
{
    public static bool DrawBoxHandle
    {
        get{ return EditorPrefs.GetBool("IsLevelEditorEnabled", true);}
        set{ EditorPrefs.SetBool("IsLevelEditorEnabled", value);}
    }



}
