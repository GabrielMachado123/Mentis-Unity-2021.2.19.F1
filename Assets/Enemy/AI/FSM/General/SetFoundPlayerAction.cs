using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Finite State Machine/actions/FoundPlayer")]

public class SetFoundPlayerAction : action
{
    [SerializeField] private int var;

    public override void Act(FiniteStaFiniteStateMachine fsm)
    {

        fsm.GetAgent().SetFoundPlayer(var);



    }
}
