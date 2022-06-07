using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/Transition")]

public class Transition : ScriptableObject
{
    [SerializeField]
    private Condition decision;
    [SerializeField]
    private action action;
    [SerializeField]
    private State targetState;

    public bool IsTriggered(FiniteStaFiniteStateMachine fsm)
    {

        return decision.Test(fsm);
    }


    public State GetTargetState()
    {
        return targetState;
    }

    public action GetAction()
    {
        return action;
    }
}
