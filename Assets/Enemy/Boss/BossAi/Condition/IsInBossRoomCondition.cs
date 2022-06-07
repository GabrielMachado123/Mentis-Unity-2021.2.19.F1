using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Boss/Condition")]
public class IsInBossRoomCondition : Condition
{
    private bool Go;
    public override bool Test(FiniteStaFiniteStateMachine fsm)
    {
        


        if (fsm.GetBoss().ck.IsInBossRoom)
        {
          
            return !Go;
        }
        else
        {
            
            return Go;
        }


    }
}
