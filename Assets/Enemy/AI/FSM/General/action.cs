using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class action : ScriptableObject
{
    public abstract void Act(FiniteStaFiniteStateMachine fsm);
  
}
