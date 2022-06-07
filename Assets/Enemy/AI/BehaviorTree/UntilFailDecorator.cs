using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntilFailDecorator : Decorator
{
  public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {
        if( status == TaskStatus.None)
        {
            status = TaskStatus.Running;
        }

        if(worldManager.IsInBossRoom())
        {
            Debug.Log("Sucess");
            status = TaskStatus.Success;
        }

        return status;
    }
}
