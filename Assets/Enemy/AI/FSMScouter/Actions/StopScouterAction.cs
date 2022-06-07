using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/StopScouter")]
public class StopScouterAction : action
{
    public override void Act(FiniteStaFiniteStateMachine fsm)
    {
       
        fsm.GetFlyingAgent().Stop();
    }
}

