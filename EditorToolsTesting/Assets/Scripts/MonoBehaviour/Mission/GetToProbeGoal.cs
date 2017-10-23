using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToProbeGoal : Goal {
    

    protected override bool CheckIsCompleted()
    {
        if (myListOfObjectives == null)
            return false;

        return myListOfObjectives[myListOfObjectives.Count -1].isCompleted;
    }

    //   // Use this for initialization
    void Start()
    {
        Description = "Get to the Choppaa!!";
    }

    //// Update is called once per frame
    //void Update () {

    //}
}
