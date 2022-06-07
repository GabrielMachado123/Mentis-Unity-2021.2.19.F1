using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/InColdownSC")]
public class InColdwonScouter : Condition
{
    [SerializeField]
    private bool negation;




    public override bool Test(FiniteStaFiniteStateMachine fsm)
    {


        Debug.Log("Testing");

        if (fsm.GetFlyingAgent().HasAttacked == true)
        {

            Debug.Log("Its in coldown");
            return !negation;
        }

        return negation;
    }
}
