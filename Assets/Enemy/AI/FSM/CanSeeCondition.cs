using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/CanSee")]
public class CanSeeCondition : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;




    public override bool Test(FiniteStaFiniteStateMachine fsm)
    {
       
        
        Transform target = fsm.GetAgent().target;
        Vector3 direction = target.position - fsm.transform.position;
        float distance = direction.magnitude;
        float angle = Vector3.Angle(direction.normalized, fsm.transform.forward);
        if((angle < viewAngle) && (distance < viewDistance))
        {
         
            
            return !negation;
        }
        
        return negation;
    }
}
