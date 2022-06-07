using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {
        int failureCount = 0;
        foreach (Task task in children)
        {
            if (task.status != TaskStatus.Failure)
            {
                TaskStatus childStatus = task.Run(agent, worldManager);

                if (childStatus == TaskStatus.Success)
                {
                    status = TaskStatus.Success;
                    return status;
                }
                else if (childStatus == TaskStatus.Failure)
                {
                    failureCount++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                failureCount++;
            }
        }

        if (failureCount == children.Count)
        {
            status = TaskStatus.Failure;
        }
        else
        {
            status = TaskStatus.Running;
        }
        return status;

    }
}
