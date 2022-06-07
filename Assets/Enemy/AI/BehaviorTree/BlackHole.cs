using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {



        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }

      
        if (worldManager.haveCastedBlackHole == false && worldManager.stage == 3)
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            worldManager.BlackHole();
        }
        else
        {
            status = TaskStatus.Success;
        }
       







        return status;

    }
}
