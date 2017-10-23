using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective: MonoBehaviour {


    //[SerializeField]
    protected string description;
    public string Description
    {
        get
        {
            return description;
        }
        set { description = value; }
    }

  //[NetworkData(typeof(bool),NetworkData.NetDatType.Inconsistent)]
    public bool isCompleted;

    public delegate void ObjectiveEventDel();

    public event ObjectiveEventDel onObjectiveStartEvent;
    public event ObjectiveEventDel onObjectiveEndEvent;

   // [HideInInspector]
    public GameObject Player;

  

    //public  virtual void SetPlayer(GameObject aPlayer) { player = aPlayer; }

    protected abstract bool CheckIsCompleted();
   protected virtual void CompleteObjective() { Complete(); }
    //protected virtual void CompleteObjective() { TryTransferOwnership(PhotonNetwork.player.ID); isCompleted = true; }

    public virtual void OnObjectiveStart()
    {
        if (onObjectiveStartEvent != null)
            onObjectiveStartEvent();
    }

    public virtual void Complete()
    {
        Debug.Log("Completed");

        isCompleted = true;

        if (onObjectiveEndEvent != null)
            onObjectiveEndEvent();
    }

    public virtual void UpdateObjective()
    {
        if (isCompleted)
            return;

        if (CheckIsCompleted())
            CompleteObjective();
    }


}
