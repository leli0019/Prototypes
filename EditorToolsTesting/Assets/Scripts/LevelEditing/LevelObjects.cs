using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LevelObjectData  {
    public string Name;
    public GameObject Prefab;
}


[CreateAssetMenu]
public class LevelObjects : ScriptableObject
{
    public List<LevelObjectData> objects = new List<LevelObjectData>();

}