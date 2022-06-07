using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Conditions/CanSeeScouter")]
public class ScouterCanSee : Condition
{
    [SerializeField]
    private bool negation;
    [SerializeField]
    private float viewAngle;
    [SerializeField]
    private float viewDistance;




    public override bool Test(FiniteStaFiniteStateMachine fsm)
    {
    

        Transform target = fsm.GetFlyingAgent().target;
        Vector3 direction = target.position - fsm.transform.position;
        float distance = direction.magnitude;
        float angle = Vector3.Angle(direction.normalized, fsm.transform.forward);
        if ((angle < viewAngle) && (distance < viewDistance))
        {

            Debug.Log("Test can see");
            return !negation;
        }

        return negation;
    }
}