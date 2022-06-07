using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : Task
{
   


    

    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {


        

        if (status == TaskStatus.None)
        {
           
            status = TaskStatus.Running;
        }

        if(worldManager.ChecklevOver())
        {

            status = TaskStatus.Success;
        }
        else if(worldManager.IsInBossRoom())
        {
          
            worldManager.moveset = true;
            worldManager.Levitate();
        }
    
           
        


        return status;
     
    }
}
