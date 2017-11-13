using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusGizmo : MonoBehaviour {

    public Color color;
    public float radius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);

    }
}
