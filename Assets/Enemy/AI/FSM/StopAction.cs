using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/Stop")]
public class StopAction : action
{
    public override void Act(FiniteStaFiniteStateMachine fsm)
    {
     
        fsm.GetAgent().Stop();
    }
}
