using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/Patrol")]
public class PatrolAction : action
{
   public override void Act(FiniteStaFiniteStateMachine fsm)
    {
        if (fsm.GetAgent().IsAtDestionation())
        {
            fsm.GetAgent().GotoNextWaypoint();
        }
     
    }
}
