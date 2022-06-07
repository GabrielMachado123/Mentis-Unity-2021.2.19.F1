using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStage3 : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {



        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }



        Debug.Log(worldManager.stage);


        if (worldManager.stage == 3)
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
