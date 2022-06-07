using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/Attack")]
public class AttackAction : action
{
  
    public override void Act(FiniteStaFiniteStateMachine fsm)
    {

        fsm.GetAgent().Attack();

      
    }

  
}
