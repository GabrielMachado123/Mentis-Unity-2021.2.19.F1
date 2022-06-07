using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/EnableAttackScript")]
public class EnableAtt : action
{

    public override void Act(FiniteStaFiniteStateMachine fsm)
    {


        fsm.enableAttack();
       

    }
}
