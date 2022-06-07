using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Boss/Condition/IsLevOver")]
public class IsLepOver : Condition
{
    private bool Go;
    public override bool Test(FiniteStaFiniteStateMachine fsm)
    {
        if (fsm.GetBoss().LevOver)
        {

            return !Go;
        }
        else
        {

            return Go;
        }


    }
}
