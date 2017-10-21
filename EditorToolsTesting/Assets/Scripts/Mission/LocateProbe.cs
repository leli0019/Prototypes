using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateProbe : Objective
{
    
    private GameObject probe;

    private float zoneRadius = 50.0f;

  
    public override void OnObjectiveStart()
    {
        base.OnObjectiveStart();
        probe = GameObject.Find("Probe");
    }
  
    protected override bool CheckIsCompleted()
    {
    
        Vector3 displacement = probe.transform.position - player.transform.position;

       return displacement.magnitude < zoneRadius;
    }

 


}
