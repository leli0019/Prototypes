using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeMission : Mission
{

    private void Start()
    {
        InitMission();
        StartMission();
    }

    private void InitMission()
    {
        foreach(Goal goal in transform.GetComponentsInChildren<Goal>())
        {
            listOfGoals.Add(goal);
        }
    }

    public override void StartMission()//GameObject player)
    {

        foreach (Goal goal in listOfGoals)
        {
            goal.InitGoal();
        }
        listOfGoals[0].OnObjectiveStart();
        MissionStarted = true;
    }

 

}
