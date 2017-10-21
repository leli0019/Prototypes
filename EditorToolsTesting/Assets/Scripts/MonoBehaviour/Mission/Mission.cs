using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using System;

public enum Roles {Driver,Navigator,Scientist };


public abstract class Mission : MonoBehaviour {

    [SerializeField]
    protected List<Goal> listOfGoals;
    [SerializeField]
    protected Text goalUI;
    [SerializeField]
    protected Text objectiveUI;

    //protected Goal LastGoal;

    protected bool MissionStarted = false;




    public abstract void StartMission(GameObject player);

   

    void Update()
    {
        if (MissionStarted == false)
            return;
        

        if (listOfGoals.Count > 0)
        {
           
            listOfGoals[0].UpdateObjective();
            UpdateUI();

            if (listOfGoals[0].isCompleted)
            {
                listOfGoals.RemoveAt(0);

                if(listOfGoals.Count > 0)
                listOfGoals[0].OnObjectiveStart();
            }

        }
        else
        {
            CompleteMission();
        }


    }

    public void SubscribeToObjectiveStartEvent<T>(Roles role, Objective.ObjectiveEventDel callback) where T : Objective
    {
        foreach(Goal goal in listOfGoals)
        {
            if (goal is T)
            {
                goal.onObjectiveStartEvent += callback;
            }
            Objective objective = goal.GetObjective<T>(role);
            if (objective != null)
                objective.onObjectiveStartEvent += callback;
        }
    }

    public void SubscribeToObjectiveEndEvent<T>(Roles role, Objective.ObjectiveEventDel callback) where T : Objective
    {
        foreach (Goal goal in listOfGoals)
        {
            Objective objective = goal.GetObjective<T>(role);
            if (objective != null)
                objective.onObjectiveEndEvent += callback;
        }
    }



    protected virtual void UpdateUI()
    {
        goalUI.text = listOfGoals[0].Description;
        objectiveUI.text = listOfGoals[0].GetCurrentObjectiveDescription();       
    }
    
    protected virtual void CompleteMission()
    {
        goalUI.text = "MissionCompleted";
        objectiveUI.text = "";
    }
    
  
}
