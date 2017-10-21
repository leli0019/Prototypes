using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
    Grid grid;

    static bool isInitialized = false;

 

    public void OnEnable()
    {
        grid = (Grid)target;
        Debug.Log(isInitialized);
        if(isInitialized == false)        
         SceneView.onSceneGUIDelegate += GridUpdate;

        isInitialized = true;
    }
   
    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(" Grid Width ");
        grid.width = EditorGUILayout.FloatField(grid.width, GUILayout.Width(50));
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        GUILayout.Label(" Grid Height ");
        grid.height = EditorGUILayout.FloatField(grid.height, GUILayout.Width(50));
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Open Grid Window", GUILayout.Width(255)))
        {
            GridWindow window = (GridWindow)EditorWindow.GetWindow(typeof(GridWindow));
            window.Init();
        }

        SceneView.RepaintAll();
    }

    public void GridUpdate(SceneView sceneview)
    {
        Event e = Event.current;

        Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
        Vector3 mousePos = r.origin;

        if(e.isKey && e.character == 'a')
        {
            Debug.Log("Creating cube");
            GameObject obj;
            Object prefab = PrefabUtility.GetPrefabParent(Selection.activeObject);
            if(prefab)
            {                
                obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                Vector3 alignedPos = new Vector3(Mathf.Floor(mousePos.x / grid.width) * grid.width + grid.width * 0.5f,
                                               Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.height * 0.5f,
                                               0.0f);

                obj.transform.position = alignedPos;
                Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            }
        }

        else if (e.isKey && e.character == 'd')
        {
            foreach (GameObject go in Selection.gameObjects)
                DestroyImmediate(go);

        }
    }

}