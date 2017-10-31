using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomScript))]
public class CustomInspector : Editor {

    CustomScript yourscript;

    bool showFloats;
    private void OnEnable()
    {
        yourscript = (CustomScript)target;
        showFloats = false;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if( showFloats = GUILayout.Toggle(showFloats, "Show/Hide", GUI.skin.button))
        {
            yourscript.testfloat1 = EditorGUILayout.FloatField("TestingFloat", yourscript.testfloat1);
            yourscript.testfloat2 = EditorGUILayout.FloatField("TestingFloat", yourscript.testfloat2);
        }
    }

}
