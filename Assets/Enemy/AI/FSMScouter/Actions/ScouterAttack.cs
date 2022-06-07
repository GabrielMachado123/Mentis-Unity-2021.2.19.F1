using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/actions/AttackScouter")]
public class ScouterAttack : action
{

    public override void Act(FiniteStaFiniteStateMachine fsm)
    {
        Debug.Log("HEY I ATTACK");

        fsm.GetFlyingAgent().Attack();


    }


}