using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDeterministic : Task
{
    private bool shuffledOrder;
    public NonDeterministic()
    {
        shuffledOrder = false;
    }
    public override TaskStatus Run(BehaviorTreeAgent agent,
    WorldManager worldManager)
    {
        if (!shuffledOrder)
        {
            Shuffle(children);
            shuffledOrder = true;
        }

        int successCount = 0;

        foreach (Task task in children)
        {
            if (task.status != TaskStatus.Success)
            {
                TaskStatus childStatus = task.Run(agent, worldManager);
                if (childStatus == TaskStatus.Failure)
                {
                    status = TaskStatus.Failure;
                    return status;
                }
                else if (childStatus == TaskStatus.Success)
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
        if (successCount == children.Count)
        {
            status = TaskStatus.Success;
        }
        else
        {
            status = TaskStatus.Running;
        }
        return status;
    }




    public void Shuffle(List<Task> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            int k = Random.Range(0, n);
            Task value = list[k];
            list[k] = list[n - 1];
            list[n - 1] = value;
            n--;
        }
    }
}
