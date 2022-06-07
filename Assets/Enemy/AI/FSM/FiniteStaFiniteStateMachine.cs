using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStaFiniteStateMachine : MonoBehaviour
{
    public State initialState;
    private State currentState;
    private Patrol agent;
    private AttackOverseer AttOv;

    private BossMain Boss;

    private FlyingAgent Fagent;

    void Start()
    {
        currentState = initialState;

        Boss = GetComponent<BossMain>();

        agent = GetComponent<Patrol>();
        AttOv = GetComponent<AttackOverseer>();
        Fagent = GetComponent<FlyingAgent>();
    }

    public BossMain GetBoss()
    {
        return Boss;
    }
    public AttackOverseer GetAttOv()
    {
        return AttOv;
    }

    public void disableAttack()
    {
        AttOv.enabled = false;
    }

    public void enableAttack()
    {
        AttOv.enabled = true;
    }


    public FlyingAgent GetFlyingAgent()
    {
        return Fagent;
    }

    public Patrol GetAgent()
    {
        return agent;
    }

    void Update()
    {
        Transition triggeredTransition = null;
        foreach(Transition transition in currentState.GetTransitions())
        {
            if(transition.IsTriggered(this))
            {
                triggeredTransition = transition;
                break;
            }
        }
        List<action> actions = new List<action>();

        if (triggeredTransition)
        {
            State targetState = triggeredTransition.GetTargetState();
            actions.Add(currentState.GetExitAction());
            actions.Add(triggeredTransition.GetAction());
            actions.Add(targetState.GetEntryAction());
            currentState = targetState;
        }
        else
        {
            foreach(action action in currentState.GetStateActions())
            {
                actions.Add(action);
            }
        }

        foreach(action action in actions)
        {
            if(action)
            {
                action.Act(this);
            }
        }
    }
}
