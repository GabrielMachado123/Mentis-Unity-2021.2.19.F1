using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Finite State Machine/actions/DisableAttackScript")]
public class DisableAttack : action
{

    

    public override void Act(FiniteStaFiniteStateMachine fsm)
    {


        fsm.disableAttack();


    }

  
    


}
