using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class Tools
{
    public static bool isLevelEditorEnabled
    {
        get{ return EditorPrefs.GetBool("IsLevelEditorEnabled", true);}
        set{ EditorPrefs.SetBool("IsLevelEditorEnabled", value);}
    }

    public static int SelectedLevelEditorTool
    {
        get { return EditorPrefs.GetInt("SelectedLevelEditorTool", 0); }
        set
        {
            if (value == SelectedLevelEditorTool)
                return;
            switch (value)
            {
                case 0:
                    EditorPrefs.SetBool("IsLevelEditorEnabled", false);
                    EditorPrefs.SetInt("SelectedLevelEditorTool", value);
                    UnityEditor.Tools.hidden = false;
                    break;

                case 1:
                    EditorPrefs.SetBool("IsLevelEditorEnabled", true);
                    EditorPrefs.SetInt("SelectedLevelEditorTool", value);
                    UnityEditor.Tools.hidden = true;
                    break;

                case 2:
                    EditorPrefs.SetBool("IsLevelEditorEnabled", true);
                    EditorPrefs.SetInt("SelectedLevelEditorTool", value);
                    UnityEditor.Tools.hidden = true;
                    break;

            }


        }
    }


}


