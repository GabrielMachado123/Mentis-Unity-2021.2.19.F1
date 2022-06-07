using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/Chase")]
public class Chase : action
{
    public override void Act(FiniteStaFiniteStateMachine fsm)
    {
        if (fsm.GetAgent().IsAtDestionation())
        {
          
            fsm.GetAgent().GoToTarget();
          
        }
        
    }
}
