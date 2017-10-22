using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityObjective : Objective {

    public GameObject Player;
    public GameObject Target;
    public float ZoneRadius;

    bool isComplete = false;    

    private void Start()
    {
        //RadiusGizmo gizmo = TargetPos.AddComponent<RadiusGizmo>();
        //gizmo.radius = ZoneRadius;
    }

    protected override bool CheckIsCompleted()
    {
        return Vector3.Distance(Player.transform.position, Target.transform.position) < ZoneRadius;
    }
}
