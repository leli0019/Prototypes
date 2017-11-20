using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher: MonoBehaviour
{
   public Vector3 startingPos;

    public void Fall(Vector3 pos)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        startingPos = pos;

        transform.position = startingPos;

    }
 
}
