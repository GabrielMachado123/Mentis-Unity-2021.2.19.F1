using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStage2 : Task
{

    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {




        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }

        worldManager.Move2();


       if(worldManager.Move2Over)
        {
            worldManager.Move2Over = false;
            status = TaskStatus.Success;

        }
        
        






        return status;

    }
}
