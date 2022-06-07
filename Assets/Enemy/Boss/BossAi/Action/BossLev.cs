using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Boss/actions/Levitate")]
public class BossLev : action
{
    public override void Act(FiniteStaFiniteStateMachine fsm)
    {
           
            fsm.GetBoss().Levitate();
         
        

    }
}
