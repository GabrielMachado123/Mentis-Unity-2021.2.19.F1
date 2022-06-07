using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack12 : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {



        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }


       
        worldManager.attack12();
              

      

        if (worldManager.animEnded)
        {
            worldManager.animEnded = false;
            status = TaskStatus.Success;
        }

        return status;

    }
}

