using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysSuceed : Task
{

    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {
        status = TaskStatus.Success;
        return status;

    }
}
