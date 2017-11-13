using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{

    Vector3 startingPos;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;

    }
    private void OnCollisionEnter(Collision collision)
    {
        transform.position = startingPos;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
