using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStage2 : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {



        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }






        if (worldManager.stage == 2)
        {
            Debug.Log(worldManager.stage);
            status = TaskStatus.Success;
        }
        else
        {
            
            status = TaskStatus.Failure;
        }








        return status;

    }
}
    