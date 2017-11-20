using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool{

    public  List<GameObject> activeObjects;//= new List<GameObject>();
    public  List<GameObject> inactiveObjects;// = new List<GameObject>();


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public ObjectPool(GameObject go, float size)
    {
        activeObjects = new List<GameObject>();
        inactiveObjects = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject obj = GameObject.Instantiate(go);
            obj.SetActive(false);
            inactiveObjects.Add(obj);
        }
    }

   public GameObject GetInactive()
    {
        GameObject go = null;

        if (inactiveObjects.Count > 0)
        {
            go = inactiveObjects[0];
            go.SetActive(true);
            activeObjects.Add(go);

            inactiveObjects.RemoveAt(0);
        }
        return go;
    }
    public void AddToInactive(GameObject go)
    {
        
        go.SetActive(false);
        inactiveObjects.Add(go);

        for (int i = 0; i < activeObjects.Count; i++)
        {
            if (activeObjects[i] == go)
                activeObjects.RemoveAt(i); 
        }
    }
    


}
