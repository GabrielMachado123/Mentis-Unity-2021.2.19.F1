using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/RepositionSC")]
public class RepositionSc : action
{

    public override void Act(FiniteStaFiniteStateMachine fsm)
    {

        fsm.GetFlyingAgent().Reposition();



    }
}

