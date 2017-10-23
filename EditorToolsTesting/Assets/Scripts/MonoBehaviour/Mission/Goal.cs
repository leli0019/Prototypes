using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class Goal : Objective
{

    [SerializeField]
    protected List<Objective> listOfDriverObjectives;
    [SerializeField]
    protected List<Objective> listOfNavigatorObjectives;
    [SerializeField]
    protected List<Objective> listOfScientistObjectives;


    protected List<Objective> myListOfObjectives;

    [HideInInspector]
    public Objective lastObjective;

    // Use this for initialization

    public override void OnObjectiveStart()
    {
        base.OnObjectiveStart();


        //myListOfObjectives = listOfDriverObjectives;

        switch (Player.name)
        {
            case "Driver":
                myListOfObjectives = listOfDriverObjectives;
                break;

            case "Navigator":
                myListOfObjectives = listOfNavigatorObjectives;
                break;

            case "Scientist":
                myListOfObjectives = listOfScientistObjectives;
                break;
        }




    }

    //public override void SetPlayer(GameObject aPlayer)
    //{


    //    base.SetPlayer(aPlayer);

    //    foreach (Objective objective in listOfDriverObjectives)
    //    {
    //        objective.SetPlayer(aPlayer);
    //    }
    //    foreach (Objective objective in listOfNavigatorObjectives)
    //    {
    //        objective.SetPlayer(aPlayer);
    //    }
    //    foreach (Objective objective in listOfScientistObjectives)
    //    {
    //        objective.SetPlayer(aPlayer);
    //    }

    //}


    public override void UpdateObjective()
    {
        if (CheckIsCompleted() == false)
        {
            foreach (Objective objective in myListOfObjectives)
            {
                if (objective.isCompleted == false)
                {
                    if (lastObjective != objective)
                    {
                        objective.OnObjectiveStart();
                        lastObjective = objective;
                    }

                    objective.UpdateObjective();
                    break;
                }
            }

            if (myListOfObjectives.Count > 0)
            {
                if (myListOfObjectives[myListOfObjectives.Count - 1].isCompleted)
                    lastObjective.Description = "Standby";
            }

        }
        else
            CompleteObjective();

    }

    public string GetCurrentObjectiveDescription()
    {
        if (myListOfObjectives.Count == 0 || lastObjective == null)
            return "Standby";

        if (myListOfObjectives[myListOfObjectives.Count - 1].isCompleted)
            return "Standby";
        else
            return lastObjective.Description;

    }

    public Objective GetObjective<T>(Roles role) where T : Objective
    {
        switch (role)
        {
            case Roles.Driver:

                foreach (Objective objective in listOfDriverObjectives)
                {
                    if (objective is T)
                        return objective;
                }
                break;

            case Roles.Navigator:
                foreach (Objective objective in listOfNavigatorObjectives)
                {
                    if (objective is T)
                        return objective;
                }
                break;

            case Roles.Scientist:
                foreach (Objective objective in listOfScientistObjectives)
                {
                    if (objective is T)
                        return objective;
                }
                break;

        }

        return null;

    }


    public void SetupSubObjectiveCallbacks()
    {
        ObjectiveEventDel startDel = OnSubObjectiveStart;
        ObjectiveEventDel endDel = OnSubObjectiveEnd;

        foreach (Objective objective in listOfDriverObjectives)
        {
            objective.onObjectiveStartEvent += startDel;
            objective.onObjectiveEndEvent += endDel;
        }
        foreach (Objective objective in listOfNavigatorObjectives)
        {
            objective.onObjectiveStartEvent += startDel;
            objective.onObjectiveEndEvent += endDel;
        }
        foreach (Objective objective in listOfScientistObjectives)
        {
            objective.onObjectiveStartEvent += startDel;
            objective.onObjectiveEndEvent += endDel;
        }
    }

    protected virtual void OnSubObjectiveEnd() { }
    protected virtual void OnSubObjectiveStart() { }



}
