using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasJumped : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {

        
        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }
       
        
        if (!worldManager.AlreadySummon)
        {
            Debug.Log("2");
            worldManager.BossSummonSword();

            if (worldManager.animEnded)
            {
                worldManager.animEnded = false;
                status = TaskStatus.Success;
            }
        }
        else
        {
          
            status = TaskStatus.Success;
        }

        
       








        return status;

    }
}
