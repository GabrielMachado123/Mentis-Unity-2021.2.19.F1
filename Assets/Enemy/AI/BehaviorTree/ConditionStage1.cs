using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStage1 : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {

        

        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }





        if (worldManager.stage == 1)
        {

            
            status = TaskStatus.Success;
        }
        else
        {
            status = TaskStatus.Failure;
        }








        return status;

    }
}
