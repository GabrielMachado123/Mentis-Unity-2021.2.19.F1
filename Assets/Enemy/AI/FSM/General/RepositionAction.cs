using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/Reposition")]
public class RepositionAction : action
{

    public override void Act(FiniteStaFiniteStateMachine fsm)
    {

        fsm.GetAgent().Reposition();



    }

}
