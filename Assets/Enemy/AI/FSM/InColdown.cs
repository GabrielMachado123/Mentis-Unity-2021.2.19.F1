using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/InColdown")]
public class InColdown : Condition
{
    [SerializeField] 
    private bool negation;
 



    public override bool Test(FiniteStaFiniteStateMachine fsm)
    {
        


       if(fsm.GetAttOv().HasAttacked == true)
        {
            
          
            return !negation;
        }

        return negation;
    }
}
