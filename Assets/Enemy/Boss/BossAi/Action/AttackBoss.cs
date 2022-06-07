using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Boss/action/Attack")]
public class AttackBoss : action
{
    public override void Act(FiniteStaFiniteStateMachine fsm)
    {

        fsm.GetBoss().Attack();



    }
}
