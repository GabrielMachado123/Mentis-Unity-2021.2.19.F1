using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/ChaseScout")]
public class ChaseScouterAct : action
{
    public override void Act(FiniteStaFiniteStateMachine fsm)
    {
        if (fsm.GetFlyingAgent().IsAtDestionation())
        {
            
            fsm.GetFlyingAgent().GoToTarget();
        }
        
    }
}
