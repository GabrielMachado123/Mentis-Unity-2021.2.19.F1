using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Boss/actions/DecideAttack")]
public class DecideAttAct : action
{

    public override void Act(FiniteStaFiniteStateMachine fsm)
    {

        fsm.GetBoss().DecideAttack();



    }
}
