using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {
        int successCount = 0;

        foreach(Task task in children)
        {
            if( task.status != TaskStatus.Success)
            {
                TaskStatus childStatus = task.Run(agent, worldManager);
                if(childStatus == TaskStatus.Failure)
                {
                    status = TaskStatus.Failure;
                    return status;
                }
                else if(childStatus == TaskStatus.Success)
                {
                    successCount++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                successCount++;
            }
        }
        if(successCount == children.Count)
        {
            status = TaskStatus.Success;
        }
        else
        {
            status = TaskStatus.Running;
        }
        return status;
    }
}
