using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RadiusGizmo))]
public class RadiusGizmoEditor : Editor {

    RadiusGizmo targetScript;

    private void OnEnable()
    {
        targetScript = (RadiusGizmo)target;
    }
    // Update is called once per frame
    void Update () {
		
	}

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}
