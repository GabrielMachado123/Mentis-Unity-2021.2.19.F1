using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RepositionInBehaviour : Task
{
    public override TaskStatus Run(BehaviorTreeAgent agent, WorldManager worldManager)
    {

        if (status == TaskStatus.None)
        {

            status = TaskStatus.Running;
        }

      
           if(worldManager.isRepover())
        {
            status = TaskStatus.Success;
        }
           else
        {
        
            worldManager.Reposition();
        }
           
   





        return status;
    }
}



