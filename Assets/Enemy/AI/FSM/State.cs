using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Finite State Machine/State")]
public class State : ScriptableObject
{
    [SerializeField]
    private action entryAction;
    [SerializeField]
    private action[] stateActions;
    [SerializeField]
    private action exitAction;
    [SerializeField]
    private Transition[] transitions;


    public action GetEntryAction()
    {
        return entryAction;
    }

    public action[] GetStateActions()
    {
        return stateActions;
    }

    public action GetExitAction()
    {
        return exitAction;
    }

    public Transition[] GetTransitions()
    {
        return transitions;
    }

}
