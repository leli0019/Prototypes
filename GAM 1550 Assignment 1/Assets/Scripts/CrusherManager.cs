using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherManager : MonoBehaviour
{

    public GameObject reference;
    public float size;
    public List<Transform> spawnPoints;
    public float minHeight;

    ObjectPool pool;

    // Use this for initialization
    void Start()
    {
        pool = new ObjectPool(reference, 10);

        foreach (Transform t in spawnPoints)
        {
            Crusher crusher = pool.GetInactive().GetComponent<Crusher>();
            crusher.Fall(t.position);
        }



    }
    // Update is called once per frame
    void Update()
    {

        for (int i = pool.activeObjects.Count; i > 0; i--)
        {
            GameObject activeObj = pool.activeObjects[i - 1];
            if (activeObj.transform.position.y <= minHeight)
            {
                Crusher crusher = activeObj.GetComponent<Crusher>();
                SpawnNew(crusher.startingPos);
                pool.AddToInactive(activeObj);
            }
        }

    }

    void SpawnNew(Vector3 pos)
    {
        GameObject newCrusher = pool.GetInactive();
        newCrusher.GetComponent<Crusher>().Fall(pos);
    }


}
