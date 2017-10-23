using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeMission : Mission
{

    private void Start()
    {
        StartMission();
    }

    public override void StartMission()//GameObject player)
    {


        //  GameObject driver = GameObject.Find("Driver");


        //foreach (Goal goal in listOfGoals)
        //{
        //    goal.SetPlayer(player);
        //    goal.SetupSubObjectiveCallbacks();
        //}
        listOfGoals[0].OnObjectiveStart();
        MissionStarted = true;
    }

}
