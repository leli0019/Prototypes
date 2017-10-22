using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RadiusGizmo : MonoBehaviour {

    public Color color = new Vector4(75, 225, 0, 100).normalized;
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

        Vector4 alpha = color;
        alpha.w = 1;
        Gizmos.color = alpha;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
